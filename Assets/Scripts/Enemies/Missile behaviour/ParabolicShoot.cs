using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicShoot : MonoBehaviour
{
    public Vector2 startForce;
    public float force;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(startForce * force);    
    }
}
