using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatusAct1 : PlayerStatus
{
    public static PlayerStatusAct1 instance;
    public int memory;
    public float hp;
    public TextMeshProUGUI memoryText;
    public TextMeshProUGUI hpText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        memoryText.text = memory.ToString();
        hpText.text = hp.ToString();
    }

    void Update()
    {
        
    }
}
