using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSound : MonoBehaviour
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
            SoundManager.PlaySoundLoop(SoundManager.Sound.StoneSound,SoundAssets._fx,0.15f,Random.Range(0.9f,1f));
        }
        else
        {
            SoundManager.EndSoundLoop(SoundManager.Sound.StoneSound);
        }
    }
}
