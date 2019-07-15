using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float fireRate;
    public Transform spawnPoint;
    public GameObject balaLaser;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", fireRate, fireRate);
    }

    void shoot()
    {
        GameObject g = Instantiate(balaLaser);
        g.transform.position = spawnPoint.transform.position;
    }
}
