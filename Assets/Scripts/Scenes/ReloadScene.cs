using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private RespawnPoint rp;
    private SceneChanger _sceneChanger;

    void Start()
    {
        rp = GameObject.Find("RespawnPoint").GetComponent<RespawnPoint>();
        _sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Vulture") || other.gameObject.transform.Find("CameraPos"))
        {
            if (rp.respawn)
            {
                _sceneChanger.LoadSpecificScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                _sceneChanger.LoadSpecificScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}