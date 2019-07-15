using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject boom;

    void explode()
    {
        //Spawn particles?? animation?? both?? :)
        GameObject g = Instantiate(boom);
        g.transform.position = transform.position;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject == null || collision == null)
            return;

        if (collision.gameObject.tag == "Player")
        {
            explode();
            collision.gameObject.GetComponent<PlayerDead>().dieExploded();           
            return;
        }

        if (collision.gameObject.tag == "Missile" || collision.gameObject.tag == "Obstacle")
        {
            explode();
        }
    }
}
