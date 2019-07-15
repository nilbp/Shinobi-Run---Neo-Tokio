using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePref;
    public Transform shootPoint;
    public Transform canonPart;
    public float rotSpeed = 1f;
    public float zRot;
    public float fireRate = 4;

    public float trackingSensivility = 0.01f;
    public bool dontShoot;
    public bool shootIfLastIsDestroyed;

    //Privatet variables
    protected GameObject m;
    private float shootTime = 0;
    private Vector2 dir;
    private float angle;
    private bool targetingPlayer = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (dontShoot)
                return;

            if (shootIfLastIsDestroyed)
            {
                if (m == null)
                {
                    shoot();
                }
            }
            else
            {
                if (shootTime <= 0)
                {
                    shoot();
                }
            }

            //Rotate following the player
            targetingPlayer = true;
            dir = collision.transform.position - transform.position;
            angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            canonPart.transform.rotation = Quaternion.Lerp(canonPart.transform.rotation,
                                                           Quaternion.AngleAxis(-angle - 90, Vector3.forward),
                                                           trackingSensivility);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        targetingPlayer = false;
    }

    private void Update()
    {
        /*if(!targetingPlayer)
        {
            canonPart.transform.rotation = Quaternion.AngleAxis(Mathf.Cos(Time.deltaTime), Vector3.forward);
        }*/

        if (shootTime > 0)
            shootTime -= Time.deltaTime;

    }

    public virtual void shoot()
    {
        m = Instantiate(missilePref);
        m.transform.position = shootPoint.position;
        shootTime = fireRate;
    }

}
