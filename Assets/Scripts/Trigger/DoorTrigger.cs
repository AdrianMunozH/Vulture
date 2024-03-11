using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorRight;
    public GameObject doorLeft;
    public GameObject button;
    int _objectCount = 0;
    private bool _isOpen = false;
    
    private bool _stoneOn;
    private bool _vultureOn ;
    private bool _ratOn;
    
    private Collider[] col;
    
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("isPushable"))
        {
            _stoneOn = true;
        }
        else if(col.gameObject.name.Equals("Vulture"))
        {
            _vultureOn = true;
        }else if (col.gameObject.name.Equals("RatModel2"))
        {
            _vultureOn = true;
            _ratOn = true;
        }
        TransformDoor();
    }
         
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("isPushable"))
        {
            _stoneOn = false;
        }else if (col.gameObject.name.Equals("Vulture"))
        {
            _vultureOn = false;
        }else if ( col.gameObject.name.Equals("RatModel2"))
        {
            _ratOn = false;
            _vultureOn = false;
        }
        TransformDoor();
    }
    
    
    
   private void TransformDoor()
    {
        if (((_stoneOn && _ratOn) || (_ratOn && _vultureOn) || (_vultureOn && _ratOn) || (_vultureOn && _stoneOn)) && !_isOpen )
        {
            button.transform.position -= new Vector3(0, 0.002f, 0);
            doorRight.transform.position += new Vector3(0, 0, 0.6f);
            doorLeft.transform.position -= new Vector3(0, 0, 0.6f);
            SoundManager.PlaySoundOnce(SoundManager.Sound.MetalDoorAir,SoundAssets._fx,0.2f);
            _isOpen = true;
        }else if( !((_stoneOn && _ratOn) || (_ratOn && _vultureOn)  || (_vultureOn && _ratOn) || (_vultureOn && _stoneOn)) && _isOpen){
            button.transform.position += new Vector3(0, 0.002f, 0);
            doorRight.transform.position -= new Vector3(0, 0, 0.6f);
            doorLeft.transform.position += new Vector3(0, 0, 0.6f);
            SoundManager.PlaySoundOnce(SoundManager.Sound.MetalDoorAir,SoundAssets._fx,0.2f);
            _isOpen = false;
        }
    }
}
