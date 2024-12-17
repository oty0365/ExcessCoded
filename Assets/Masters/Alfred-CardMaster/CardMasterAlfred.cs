using System;
using System.Collections;
using System.Collections.Generic;
using system;
using UnityEngine;

public class CardMasterAlfred : MonoBehaviour
{
    private Animator _ani;

    private void Start()
    {
        _ani = GetComponent<Animator>();
    }

    public void ShakeHand()
    {
        Conversation.pause = true;
        Debug.Log(1);
        _ani.SetInteger("behave",1);

    }

    public void ReturnHand()
    {
        _ani.SetInteger("behave",0);
        Conversation.pause = false;
    }
}
