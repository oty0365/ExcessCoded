using System.Collections;
using System.Collections.Generic;
using system;
using UnityEngine;

public class CardMasterAlfred : MonoBehaviour
{
    public Animator _ani;
    public void ShakeHand()
    {
        _ani.SetInteger("behave",1);
        Conversation.pause = true;
    }

    public void ReturnHand()
    {
        _ani.SetInteger("behave",0);
        Conversation.pause = false;
    }
}
