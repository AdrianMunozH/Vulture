using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras = new CinemachineVirtualCamera[2];

    private bool isZoomed;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (!isZoomed)
        {
            switchCamerasUp();
            isZoomed = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (isZoomed)
        {
            switchCamerasDown();
            isZoomed = false;
        }
    }

    private void switchCamerasUp()
    {
        Debug.Log("Up");
        virtualCameras[1].gameObject.SetActive(true);
        virtualCameras[0].gameObject.SetActive(false);

    }
    
    private void switchCamerasDown()
    {
        Debug.Log("Down");
        virtualCameras[0].gameObject.SetActive(true);
        virtualCameras[1].gameObject.SetActive(false);
     
    }
}
