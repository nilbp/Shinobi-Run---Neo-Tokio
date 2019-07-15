using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGem : MonoBehaviour
{
    public GameObject particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject g = Instantiate(particles);
            g.transform.position = transform.position;
           

            Destroy(gameObject);
        }
    }
}
