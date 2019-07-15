using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public GameObject[] bodyParts;
    public GameObject explodeParticles;
    public GameObject camera;
    public GameObject spawnEffect;

    private Rigidbody2D partRB;

    private void Start()
    {
        spawn();
    }

    public void dieExploded()
    {
        GameObject g = Instantiate(explodeParticles);
        g.transform.position = transform.position;

        GameObject c = Instantiate(camera);
        c.transform.position = new Vector3 (transform.position.x , transform.position.y, -100);

        foreach(GameObject parts in bodyParts)
        {
            GameObject p = Instantiate(parts);
            p.transform.position = transform.position;
            partRB = p.GetComponent<Rigidbody2D>();
            partRB.AddForce(new Vector2(Random.Range(-1500,1500), Random.Range(-1500,1500)));
            partRB.AddTorque(Random.Range(-1000,1000));
        }

        Destroy(gameObject);
        return;
    }

    public void dieSliced()
    {

    }

    public void dieCrushed()
    {
        Debug.Log("Die Crushed");

        GameObject g = Instantiate(explodeParticles);
        g.transform.position = transform.position;

        GameObject c = Instantiate(camera);
        c.transform.position = new Vector3(transform.position.x, transform.position.y, -100);

        foreach (GameObject parts in bodyParts)
        {
            GameObject p = Instantiate(parts);
            p.transform.position = transform.position;
            partRB = p.GetComponent<Rigidbody2D>();
            partRB.AddForce(new Vector2(Random.Range(-200,200), -400));
            partRB.AddTorque(Random.Range(-100, 100));
        }

        Destroy(gameObject);
        return;
    }

    public void spawn()
    {
        GameObject g = Instantiate(spawnEffect);
        g.transform.position = new Vector2(transform.position.x, transform.position.y + 2.74f);
    }
}
