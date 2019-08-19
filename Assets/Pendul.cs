using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendul : MonoBehaviour
{
    public float speed;
    private float rotValue;

    private void Start()
    {
        rotValue = speed;
    }


    private void Update()
    { 
        if(transform.rotation.z < -0.5f) 
        {
            rotValue = speed;
        }

        else if(transform.rotation.z > 0.5)
        {
            rotValue = -speed;
        }

        transform.Rotate(new Vector3(0, 0, rotValue));
        Debug.Log(rotValue);
    }
}
