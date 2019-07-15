using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerDead>().dieExploded();
        }

        if(collision.gameObject.tag == "End Laser")
        {
            Destroy(gameObject);
        }
    }
}
