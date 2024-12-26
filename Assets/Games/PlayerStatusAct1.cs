using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatusAct1 : PlayerStatus
{
    public void UpdateMemory()
    {
        memoryText.text = memory.ToString();
    }

    void Update()
    {
       
    }
}
