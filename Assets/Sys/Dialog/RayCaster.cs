using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public static RayCaster instance;
    public Camera mainCam;
    public Vector3 mousePos;
    public RaycastHit hit;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(mousePos, transform.forward,out hit,Mathf.Infinity);
            Debug.Log(hit.collider);
        }

    }
}
