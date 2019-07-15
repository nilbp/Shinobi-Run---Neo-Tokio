using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public Vector2 dir;

    void Update()
    {
        transform.Translate(dir);
    }
}
