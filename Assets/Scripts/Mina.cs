using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject g = Instantiate(explosion);
            g.transform.position = gameObject.transform.position;

            collision.GetComponent<PlayerDead>().dieExploded();
            Destroy(gameObject);
        }
    }
}
