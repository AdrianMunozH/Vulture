using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LochTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public GameObject cutScene;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "RatModel2")
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "RatModel2")
        {
            triggerActive = false;
        }
    }
    
    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            cutScene.SetActive(true);
        }
    }
}
