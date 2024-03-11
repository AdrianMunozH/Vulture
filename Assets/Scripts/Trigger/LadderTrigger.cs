using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    public GameObject ladder;
    public GameObject button;
    public Material[] material;
    [SerializeField] private bool triggerActive = false;
    Renderer renderer;
    public bool ladderDown = false;
    public bool cooldown;
    public AudioClip audioClip;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = material[0];
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            if (other.gameObject.name == "MoleBoyNew")
            {
                other.GetComponent<Animator>().SetBool("canPress", true);
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (triggerActive && VirtualInputManager.Instance.DoAction && !cooldown && other.GetComponent<Rigidbody>().velocity.x >= -0.01f && other.GetComponent<Rigidbody>().velocity.x <= 0.01f)
        {
            ButtonPressCooldown();
            StartCoroutine(PressButton());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            if (other.gameObject.name == "MoleBoyNew")
            {
                other.GetComponent<Animator>().SetBool("canPress", false);
            }
        }
    }
    /*
    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E) && renderer.sharedMaterial == material[0])
        {
            StartCoroutine(PressButton());
        }
    }
    */

    IEnumerator PressButton()
    {
        yield return new WaitForSeconds(0.5f);
        
        if (!ladderDown)
        {
            Debug.Log("ladderdown false");
            ladder.GetComponent<AudioSource>().PlayOneShot(audioClip);
            ladder.transform.position -= new Vector3(0, 2, 0);
            renderer.sharedMaterial = material[1];
            ladderDown = true;
            
        }
        else
        {
            Debug.Log("ladderdown true");
            
            ladder.GetComponent<AudioSource>().PlayOneShot(audioClip);
            ladder.transform.position += new Vector3(0, 2, 0);
            renderer.sharedMaterial = material[0];
            ladderDown = false;
        }
        
    }
    private void ButtonPressCooldown()
    {
        cooldown = true;
        Invoke("ResetCooldown",1.5f);
    }

    void ResetCooldown(){
        cooldown = false;
    }
    
}
