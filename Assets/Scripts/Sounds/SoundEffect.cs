using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("isPushable"))
            {
            sound.enabled = true;
        }
        
    }
}
