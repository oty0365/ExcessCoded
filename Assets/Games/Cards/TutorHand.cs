using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorHand : MonoBehaviour
{
    public bool isDone;
    void Update()
    {
        if (this.gameObject.transform.childCount > 0 &&!isDone)
        {
            CardMasterAlfred.instance.GameTutor3();
            isDone = true;
        }
    }
}
