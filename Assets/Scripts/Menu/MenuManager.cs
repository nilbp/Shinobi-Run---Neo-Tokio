using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator anim;
    //private int jumpHash;
    //private AnimatorStateInfo stateInfo; 

    void Start()
    {
        anim = GetComponent<Animator>();
        //stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        //jumpHash = Animator.StringToHash("Jump");
    }

    void Update()
    {

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
            anim.SetBool("City", true);
            anim.SetBool("Desert", false);
            anim.SetBool("Negative", false);
            anim.SetBool("Cave", false);

            anim.SetBool("Play", false);
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
