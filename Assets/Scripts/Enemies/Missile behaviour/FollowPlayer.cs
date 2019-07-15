using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool followPlayer;
    public float followSpeed;

    private Transform playerT;

    private void Start()
    {
        if(followPlayer)
        {
            playerT = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (playerT == null)
        {
            Destroy(gameObject);
            return;
        }

        //transform.position =  Vector2.Lerp(transform.position, positionToFollow.position, followSpeed);
        //transform.position =  Vector2.LerpUnclamped(transform.position, positionToFollow.position, followSpeed);
        transform.position =  Vector2.MoveTowards(transform.position, playerT.position, followSpeed);
       /* transform.rotation = Quaternion.LookRotation(new Vector3(playerT.position.x - transform.position.x,
                                                                  playerT.position.y - transform.position.y,
                                                                  0));*/
    }
}
