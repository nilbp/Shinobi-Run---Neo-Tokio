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

    void Start()
    {
        previousPos = camera.transform.position;

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

    }
}
