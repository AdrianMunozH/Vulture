using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public bool respawn = false;

    void OnTriggerEnter(Collider other)
    {
        respawn = true;
    }
}
