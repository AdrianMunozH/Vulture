using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    public GameObject button;
    public GameObject cutSceneDown;
    public GameObject cutSceneUp;
    public Material[] material;
    Renderer renderer;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = material[0];
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "RatModel2")
        {
            cutSceneUp.SetActive(false);
            button.transform.position -= new Vector3(0, 0.02f, 0);
            button.GetComponent<Renderer>().sharedMaterial = material[1];
            cutSceneDown.SetActive(true);
        }

    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "RatModel2")
        {
            cutSceneDown.SetActive(false);
            button.transform.position += new Vector3(0, 0.02f, 0);
            button.GetComponent<Renderer>().sharedMaterial = material[0];
            cutSceneUp.SetActive(true);
        }

    }
}

