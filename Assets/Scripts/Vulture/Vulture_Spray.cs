using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Vulture_Spray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Vulture").GetComponent<VisualEffect>().SetFloat("particleMaxLifetime",4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
