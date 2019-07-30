using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerraCircular : MonoBehaviour
{
    public float rotationSpeed;
    public float speed = 10;

    private bool firstTimePicked = true;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!firstTimePicked)
                return;

            collision.gameObject.GetComponent<PlayerDead>().dieExploded();

            firstTimePicked = false;
        }
    }
}

