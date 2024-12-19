using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDeck : MonoBehaviour
{
    public void DrawPhase()
    {
        CardMasterAlfred.instance.DrawTutor();
        gameObject.SetActive(false);
    }
}
