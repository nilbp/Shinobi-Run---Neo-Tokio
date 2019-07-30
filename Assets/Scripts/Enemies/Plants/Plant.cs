using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float secondsToWait = 3f;
    private float seconds;
    private bool eat = false;
    private Animator anim;
    private bool firstTimePicked = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        seconds = secondsToWait;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!firstTimePicked)
                return;

            anim.SetBool("Eat", true);
            eat = true;
            collision.GetComponent<PlayerDead>().dieCrushed();

            firstTimePicked = false;
        }
    }


    private void FixedUpdate()
    {
        if (eat) {
            seconds -= Time.deltaTime;
        }

        if(seconds <= 0)
        {
            eat = false;
            anim.SetBool("Eat", false);
            seconds = secondsToWait;
        }
    }
}
