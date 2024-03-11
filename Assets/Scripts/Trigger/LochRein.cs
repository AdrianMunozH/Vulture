using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LochRein : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public float x = 0;
    public float y = 0;
    public float z = 0;


    void OnTriggerEnter(Collider col)
    {
        player.transform.position = new Vector3(x,y,z);
        cam.transform.position = new Vector3(x, y, z);
    }
}
