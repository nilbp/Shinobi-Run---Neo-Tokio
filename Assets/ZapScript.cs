using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapScript : MonoBehaviour
{
	public float activeTime;
	public float desactivatedTime;
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();

		StartCoroutine("zapManager");
    }

	IEnumerator zapManager()
	{		
		bool destroyed = false;

		while (!destroyed)
		{
			zapApear();
			yield return new WaitForSeconds(activeTime);
			zapDesapear();
			yield return new WaitForSeconds(desactivatedTime);


		}
	}



	private void zapApear()
    {
		anim.SetBool("Apear", true);
		anim.SetBool("Disapear", false);
	}

	private void zapDesapear()
	{
		anim.SetBool("Disapear", true);
		anim.SetBool("Apear", false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerDead>().dieExploded();
        }
    }
}