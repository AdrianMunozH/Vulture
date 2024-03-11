
using UnityEngine;
using Cinemachine;


public class ZoomIn : MonoBehaviour
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
