using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDGems : MonoBehaviour
{
    private Text gemsText;
    public int totalGems;

    void Start()
    {
        gemsText = GetComponent<Text>();
    }

    public void FixedUpdate()
    {
        gemsText.text = LevelGems.gems + "/"+ totalGems;
    }
}
