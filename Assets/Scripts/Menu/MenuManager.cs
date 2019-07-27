using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator anim;
    //private int jumpHash;
    //private AnimatorStateInfo stateInfo; 


    public Camera cam; 
    private RaycastHit2D hitInfo;
    private Ray ray;

    private enum HoverState { HOVER, NONE };
    private HoverState hover_state;
    private GameObject hoveredGO;
    private Button button;

    void Start()
    {
        anim = GetComponent<Animator>();
        //stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        //jumpHash = Animator.StringToHash("Jump");

        hover_state = HoverState.NONE;
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {

        hitInfo = Physics2D.Raycast(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);

        if (hitInfo.collider != null)
        {
            if (hover_state == HoverState.NONE)
            {
                hoveredGO = hitInfo.collider.gameObject;

                if (hoveredGO.tag == "MenuButton")
                {
                    button = hitInfo.collider.gameObject.GetComponent<Button>();
                    button.showRombo();
                }
            }
            hover_state = HoverState.HOVER;


        }
        else
        {
            if (hover_state == HoverState.HOVER)
            {
                if (hoveredGO.tag == "MenuButton")
                {
                    button.hideRombo();
                }
            }
            hover_state = HoverState.NONE;
        }

        if (hover_state == HoverState.HOVER)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(button.pressedAction());
                switch(button.pressedAction())
                {
                    case "Play":      
                        anim.SetBool("Play", true);
                        anim.SetBool("Return", false);
                        anim.SetBool("City", false);
                        break;
                    case "Ranking":
                        break;
                    case "Return":
                        anim.SetTrigger("Return");
                        anim.SetBool("Play", false);
                        anim.SetBool("City", false);
                        anim.SetBool("Negative", false);
                        anim.SetBool("Desert", false);
                        anim.SetBool("Cave", false);
                        break;
                    case "City":
                        anim.SetBool("City", true);
                        anim.SetBool("Desert", false);
                        anim.SetBool("Negative", false);
                        anim.SetBool("Cave", false);

                        anim.SetBool("Play", false);
                        break;
                    case "Desert":
                        break;
                    case "Cave":
                        break;
                    case "Negative":
                        break;
                    case "1":
                        Application.LoadLevel(1);
                        break;

                }
            }
            if (Input.GetMouseButtonUp(0))
            {
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("AnyButtonPressed");
        }
        
        if (Input.GetKeyUp(KeyCode.P))
        {
            anim.SetBool("Play", true);
            anim.SetBool("Return", false);
            anim.SetBool("City", false);
        }
        
        if (Input.GetKeyUp(KeyCode.R))
        {
            anim.SetTrigger("Return");
            anim.SetBool("Play", false);
            anim.SetBool("City", false);
            anim.SetBool("Negative", false);
            anim.SetBool("Desert", false);
            anim.SetBool("Cave", false);
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Desert", true);
            anim.SetBool("City", false);
            anim.SetBool("Negative", false);
            anim.SetBool("Cave", false);

            anim.SetBool("Play", false);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Negative", true);
            anim.SetBool("Desert", false);
            anim.SetBool("City", false);
            anim.SetBool("Cave", false);
             
            anim.SetBool("Play", false);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Cave", true);
            anim.SetBool("Desert", false);
            anim.SetBool("Negative", false);
            anim.SetBool("City", false);

            anim.SetBool("Play", false);
        }


        

    }
}
