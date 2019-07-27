using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject rombo;
    public string action;

    public virtual void showRombo()
    {
        rombo.SetActive(true);
    }

    public virtual void hideRombo()
    {
        rombo.SetActive(false);
    }

    public virtual string pressedAction()
    {
        return action;
    }
}
