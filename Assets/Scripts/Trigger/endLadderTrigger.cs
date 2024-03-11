using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLadderTrigger : MonoBehaviour
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
        if (other.GetComponent<ExtPlayerMovement>() != null)
        {

            other.GetComponent<Animator>().SetBool("endLadder",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ExtPlayerMovement>() != null)
        {

            other.GetComponent<Animator>().SetBool("endLadder",false);
        }
    }
}
