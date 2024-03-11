using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClimbTop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        // checkt ob es der Spieler ist und ob er gerade die Leiter klettert.
        if (other.GetComponent<ExtPlayerMovement>() != null && other.gameObject.tag == "Player" && (other.GetComponent<Animator>().GetBool("Down") || other.GetComponent<Animator>().GetBool("Up")))
        {
            other.GetComponent<Animator>().SetBool("testDelete",true);
            
        }
    }
}
