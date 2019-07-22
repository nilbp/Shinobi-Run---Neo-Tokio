using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    private Camera selfCamera;
    private const float floorDistance = 10; //depende del size de la camera

    public Transform[] limits; //left, right, down, up

    public float followPlayerSensibilityHorizontal;
    public float followPlayerSensibilityVertical;

    private Vector3 finalPos;

    private void Start()
    {
        selfCamera = GetComponent<Camera>();
        selfCamera.orthographicSize = 20;

        finalPos.z = -100;
    }

    void Update()
    {
        if (player == null)
            return;


        if (transform.position.y > 20)
            selfCamera.orthographicSize = Mathf.Lerp (selfCamera.orthographicSize, 20 + (player.transform.position.y - 20) * 0.1f, 0.05f);

        else
            selfCamera.orthographicSize =  Mathf.Lerp(selfCamera.orthographicSize, 20, 0.01f);



        //Horizontal Limits
        if (player.transform.position.x < limits[0].position.x)
        {
            finalPos.x = Mathf.Lerp(transform.position.x, limits[0].transform.position.x + (selfCamera.orthographicSize * 1.2f - 20), followPlayerSensibilityHorizontal * 2);         
        }

        else if(player.transform.position.x > limits[1].position.x)
        {
            finalPos.x = Mathf.Lerp(transform.position.x, limits[1].transform.position.x - (selfCamera.orthographicSize * 1.2f - 20), followPlayerSensibilityHorizontal * 2);         
        }

        else
        {
            finalPos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, followPlayerSensibilityHorizontal);
        }

        //Vertical Limits
        if (player.transform.position.y < limits[2].position.y)
        {
            finalPos.y = Mathf.Lerp(transform.position.y, limits[2].transform.position.y, followPlayerSensibilityVertical * 2);
        }

        else if (player.transform.position.y > limits[3].position.y)
        {
            finalPos.y = Mathf.Lerp(transform.position.y, limits[3].transform.position.y, followPlayerSensibilityVertical * 2);
        }

        else
        {
            finalPos.y = Mathf.Lerp(transform.position.y, player.transform.position.y, followPlayerSensibilityVertical);
        }


        

        transform.position = finalPos;

    }
}
