using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        transform.localScale = transform.localScale * 1.2f;
        Debug.Log("Mouse Over");
    }

    private void OnMouseExit()
    {
        transform.localScale = transform.localScale * 0.8f;
    }
}
