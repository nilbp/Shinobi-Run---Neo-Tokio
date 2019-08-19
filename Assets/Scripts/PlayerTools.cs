using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public Camera camera;

    public Transform b1;
    public Transform b2;

    public Vector2 paralaxScale1;
    public Vector2 paralaxScale2;

    private Vector3 previousPos;

    private bool endLevel;
    Transform point;


    private Rigidbody2D rb;

    void Start()
    {
        previousPos = camera.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Time.timeScale = 0.5f;
        }
        else
            Time.timeScale = 1f;

        b1.transform.position += new Vector3 ((previousPos.x - camera.transform.position.x)*paralaxScale1.x, (previousPos.y - camera.transform.position.y) * paralaxScale1.y ,0);
        b2.transform.position += new Vector3 ((previousPos.x - camera.transform.position.x)* paralaxScale2.x, (previousPos.y - camera.transform.position.y) * paralaxScale2.y ,0);
        previousPos = camera.transform.position;

        if(GameMaster.endLevel)
        {            
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, point.position.x, 0.4f),
                                             Mathf.MoveTowards(transform.position.y, point.position.y, 0.4f),
                                             transform.position.z);

            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, 0.08f);
        }

    }

    public void AbsorbToPoint(Transform _point)
    {
        GameMaster.endLevel = true;

        point = _point;

        rb.gravityScale = 0;

    }
}
