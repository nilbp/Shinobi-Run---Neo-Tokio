using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableButton : Button
{
    public bool unlocked;
    public GameObject nameSprite;
    public GameObject lockSprite;

    private void Start()
    {
        if(unlocked)
        {
            nameSprite.SetActive(true);
            lockSprite.SetActive(false);
        }
        else
        {
            nameSprite.SetActive(false);
            lockSprite.SetActive(true);
        }
    }

    public override void showRombo()
    {
        if (unlocked)
        {
            base.showRombo();
        }
        
    }
    public override void hideRombo()
    {
        base.hideRombo();
    }
    public override string pressedAction()
    {
        if (unlocked)
            return base.pressedAction();

        else
            return "Locked Level";
    }
}
