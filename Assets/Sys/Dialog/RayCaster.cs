using System;
using System.Collections;
using System.Collections.Generic;
using Games.Cards;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public static RayCaster instance;
    public Camera mainCam;
    public Vector3 mousePos;
    public RaycastHit hit;
    public string tag;
    public GameObject useModel;
    private void Awake()
    {
        instance = this;
        useModel.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            tag = hit.collider.tag;
            if (tag == "card")
            {
                TriggerEffexctModel();
            }
        }

    }
    public void TriggerEffexctModel()
    {
        useModel.SetActive(true);
        CardUse.instance.selectedCard = hit.collider.gameObject.GetComponent<Card>();
    }
}
