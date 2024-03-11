using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Vulture_Tighten : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Vulture").GetComponent<VisualEffect>().SetFloat("particleMaxLifetime",1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
