using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;
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
        StatusUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatusUpdate()
    {
        memoryText.text = memory.ToString();
        hpText.text = hp.ToString();
    }
}
