using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private float m_JumpForce = 1500f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private float airVelocityReduction = 1000.2f;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsObstacle;                          // A mask determining what is ground to the character
    [SerializeField] private Collider2D m_bodyCollider;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Transform m_WallCheckRight;                          // A position marking where to check for ceilings
    [SerializeField] private Transform m_WallCheckLeft;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_justTocuhWall = true;            // Whether or not the player is grounded.
    private bool m_Grounded;            // Whether or not the player is grounded.
    private bool m_TouchWallLeft;            // Whether or not the player is grounded.
    private bool m_TouchWallRight;            // Whether or not the player is grounded.
    private float m_rollTimer = 0.5f;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 velocity = Vector3.zero;
    private Animator anim;
    private PlayerDead deadM;
    private bool dieCrushed;
    private Vector3 targetVelocity;
    private Collider2D[] colliders;

	private bool doubleJump = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deadM = GetComponent<PlayerDead>();
    }

    private void Update()
    {
        if (m_Rigidbody2D.velocity.y < -70)
            dieCrushed = true;
            
    }

    private void FixedUpdate()
    {
        m_Grounded = false;
        m_TouchWallRight = false;
        m_TouchWallLeft = false;
        anim.SetBool("IsGrounded", false);
        anim.SetBool("IsWalled", false);


        colliders = Physics2D.OverlapCircleAll(m_WallCheckLeft.position, k_GroundedRadius, m_WhatIsObstacle);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_TouchWallLeft = true;
                anim.SetBool("IsWalled", true);
            }
        }

        colliders = Physics2D.OverlapCircleAll(m_WallCheckRight.position, k_GroundedRadius, m_WhatIsObstacle);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_TouchWallLeft = true;
                anim.SetBool("IsWalled", true);
            }
        }


        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.

        colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsObstacle);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                anim.SetBool("IsGrounded", true);
            }
        }
        

        //Debug.Log("Grounded:  " + m_Grounded);
        //Debug.Log("Wall: " + m_TouchWallLeft);

        if(dieCrushed && m_Grounded)
        {
            deadM.dieCrushed();
        }

        if (m_Grounded && m_rollTimer > 0)
        {
            m_rollTimer -= Time.deltaTime;
        }

        if(!m_Grounded)
        {
            m_rollTimer = 0.5f;
        }
    }


    public void Move(float move, bool crouch, bool jump, bool down)
    {
        //Animation parameters
        anim.SetFloat("SpeedX", m_Rigidbody2D.velocity.x * 6);
        anim.SetFloat("SpeedY", m_Rigidbody2D.velocity.y);
        anim.SetFloat("Roll", m_rollTimer);
        anim.SetBool("DownKey", down);

        // If crouching, check to see if the character can stand up
        /*if (crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsObstacle))
            {
                crouch = true;
            }
        }*/

        // Move the character by finding the target velocity

        if (!m_TouchWallLeft && !m_TouchWallRight)
        {
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }


			if(m_Rigidbody2D.velocity.y < -25f)
		    {
			    doubleJump = false;
		    }

			if (jump && doubleJump)
			{
				m_Rigidbody2D.velocity = Vector3.zero;

				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce * 1.15f));
				doubleJump = false;
				Debug.Log("double jump");
			}

			if (m_Grounded)
            {
                targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

				if (jump)
                {
			        Debug.Log("jump");
					m_Rigidbody2D.velocity = Vector3.zero;
					m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce*0.8f));

					doubleJump = true;
                }

            }

            

            //Reduction of the movement if he is in the air
            else if (!m_Grounded)
            {
                targetVelocity = new Vector2(move * 11f, m_Rigidbody2D.velocity.y);
				//doubleJump = true;

			}
		}

        

		if (m_TouchWallLeft || m_TouchWallRight)
        {
            dieCrushed = false;
            if (m_justTocuhWall)
            {
                targetVelocity = new Vector2(0, 0);
                m_justTocuhWall = false;
            }

            if (m_Grounded)
            {
                targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            }

            if (jump)
            {
                if (m_FacingRight)
                    m_Rigidbody2D.AddForce(new Vector2(-m_JumpForce * 1.8f, m_JumpForce * 1.2f));

                if (!m_FacingRight)
                    m_Rigidbody2D.AddForce(new Vector2(m_JumpForce * 1.8f, m_JumpForce * 1.2f));

                Flip();
				doubleJump = true;
            }

            //si no esta sortint del wall
            if (m_Rigidbody2D.velocity.y < -10)
            {

                if (down)
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -25);

                else
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
                    
            }

        }
        else
            m_justTocuhWall = true;

            
        // If crouching
        if (crouch)
        {
            // Reduce the speed by the crouchSpeed multiplier
            move *= m_CrouchSpeed;

            // Disable one of the colliders when crouching
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = false;
        }
        else
        {
            // Enable the collider when not crouching
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = true;
        }

        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        


        // If the player should jump...
        
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
