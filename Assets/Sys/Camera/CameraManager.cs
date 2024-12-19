using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public Camera[] camList;
    public Camera currentCam;
    private void Awake()
    {
        instance = this;
        currentCam = camList[0];
        UpdateCam();
    }

    public void CamChange(int camidx)
    {
        currentCam = camList[camidx];
        RayCaster.instance.mainCam = currentCam;
        UpdateCam();
    }

    private void UpdateCam()
    {
        currentCam.gameObject.SetActive(true);
        foreach (var i in camList)
        {
            if (currentCam != i)
            {
                i.gameObject.SetActive(false);
            }
        }
    }
}
