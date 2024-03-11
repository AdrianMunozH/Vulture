using System;
using UnityEngine;

public class HintControllerTwoGameObjects : HintController
{
    private bool ratJoined = false;
    public GameObject otherObject;
    
    public void OnTriggerEnter(Collider other)
    {
        if (!ShowOnce)
        {
            if (other.gameObject.name == reactTo.name && ratJoined)
            {
                StartCoroutine(ShowKeyForSeconds());
            }
        }else if (Attempts >= showAgainInAttempts)
        {
            ShowOnce = false;
        }

        if (!ratJoined && other.gameObject.name == otherObject.name)
        {
            ratJoined = true;
        }
       if (other.gameObject.name == reactTo.name)Attempts++;
    }
    
}
