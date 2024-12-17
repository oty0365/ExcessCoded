using System;
using System.Collections;
using System.Collections.Generic;
using system;
using UnityEngine;

public class CardMasterAlfred : MonoBehaviour
{
    public Animator _ani;

    public void ShakeHand()
    {
        Conversation.pause = true;
        _ani.SetInteger("behave",1);
        
    }

    public void ReturnHand()
    {
        _ani.SetInteger("behave",0);
        Conversation.pause = false;
    }
}
