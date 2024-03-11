using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSound : MonoBehaviour
{
    public Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((rg.velocity.x > 0 || rg.velocity.x < 0 ))
        {
            SoundManager.PlaySoundLoop(SoundManager.Sound.BoxSound,SoundAssets._fx,0.02f);
        }
        else
        {
            SoundManager.EndSoundLoop(SoundManager.Sound.BoxSound);
        }
    }
    
}
