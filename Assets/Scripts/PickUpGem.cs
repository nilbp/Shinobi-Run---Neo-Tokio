using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGem : MonoBehaviour
{
    public GameObject particles;
    private bool firstTimePicked = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!firstTimePicked)
                return;

            GameObject g = Instantiate(particles);
            g.transform.position = transform.position;

            LevelGems.gems++;
            Destroy(gameObject);

            firstTimePicked = false;
        }
    }
}
