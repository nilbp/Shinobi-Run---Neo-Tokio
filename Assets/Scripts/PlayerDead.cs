using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public GameObject[] bodyParts;
    public GameObject explodeParticles;
    public GameObject spawnEffect;

    private Rigidbody2D partRB;

    public bool isDead;

    private void Start()
    {
        spawn();
    }

    public void dieExploded()
    {
        if (isDead)
            return;

        GameObject g = Instantiate(explodeParticles);
        g.transform.position = transform.position;

        foreach(GameObject parts in bodyParts)
        {
            GameObject p = Instantiate(parts);
            p.transform.position = transform.position;
            partRB = p.GetComponent<Rigidbody2D>();
            partRB.AddForce(new Vector2(Random.Range(-1500,1500), Random.Range(-1500,1500)));
            partRB.AddTorque(Random.Range(-1000,1000));
        }

        Destroy(gameObject);

        isDead = true;
        return;
    }

    public void dieSliced()
    {
        if (isDead)
            return;

        //Dead code

        isDead = true;
    }

    public void dieCrushed()
    {
        Debug.Log("Die Crushed");

        if (isDead)
            return;

        GameObject g = Instantiate(explodeParticles);
        g.transform.position = transform.position;

        foreach (GameObject parts in bodyParts)
        {
            GameObject p = Instantiate(parts);
            p.transform.position = transform.position;
            partRB = p.GetComponent<Rigidbody2D>();
            partRB.AddForce(new Vector2(Random.Range(-200,200), -400));
            partRB.AddTorque(Random.Range(-100, 100));
        }

        Destroy(gameObject);

        isDead = true;

        return;
    }

    public void spawn()
    {
        GameObject g = Instantiate(spawnEffect);
        g.transform.position = new Vector2(transform.position.x, transform.position.y + 2.74f);
    }
}
