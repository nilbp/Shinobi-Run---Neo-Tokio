using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public Camera selfCamera;
    private const float floorDistance = 10; //depende del size de la camera

    public Transform leftLimit;
    public Transform rightLimit;

    private void Start()
    {
        transform.position = new Vector3(player.transform.position.x, floorDistance, -100);
        selfCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (player == null)
            return;

        if (transform.position.y > 20)
            selfCamera.orthographicSize = 20 + (player.transform.position.y - 20) * 0.1f;

        if (player.transform.position.x < leftLimit.position.x)
        {
            if (player.transform.position.y > floorDistance)
                transform.position = new Vector3(leftLimit.position.x, player.transform.position.y, -100);

            else
                transform.position = new Vector3(leftLimit.position.x, transform.position.y, -100);

            return;
        }

        else if (player.transform.position.x > rightLimit.position.x)
        {
            if (player.transform.position.y > floorDistance)
                transform.position = new Vector3(rightLimit.position.x, player.transform.position.y, -100);

            else
                transform.position = new Vector3(rightLimit.position.x, transform.position.y, -100);

            return;
        }

        else
        {
            if (player.transform.position.y > floorDistance)
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -100);

            else
                transform.position = new Vector3(player.transform.position.x, transform.position.y, -100);
        }
        
    }
}
