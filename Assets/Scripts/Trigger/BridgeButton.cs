using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public GameObject button;
    //public GameObject screen;
    //public Transform customPivot;
    public Material[] material;
    [SerializeField] private bool triggerActive = false;
    public bool bridgeActive = false;
    public GameObject cutSceneDown;
    public GameObject cutSceneUp;
    public bool cooldown;

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

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && bridgeActive)
        {
            if (other.gameObject.name == "MoleBoyNew")
            {
                other.GetComponent<Animator>().SetBool("canPress",false);
                StartCoroutine(LeaveButton());
            }
        }
    }

    private void OnTriggerStay(Collider other)
        {
            if (triggerActive && VirtualInputManager.Instance.DoAction && !cooldown && other.GetComponent<Rigidbody>().velocity.x >= -0.01f && other.GetComponent<Rigidbody>().velocity.x <= 0.01f)
            {
                
                StartCoroutine(PressButton());
                ButtonPressCooldown();
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

    IEnumerator PressButton()
    {
        if (!bridgeActive)
        {
            yield return new WaitForSeconds(0.5f);
            //screen.SetActive(false);
            button.transform.position -= new Vector3(0, 0.02f, 0);
            button.GetComponent<Renderer>().sharedMaterial = material[1];
            cutSceneDown.SetActive(true);
            //bridge.transform.RotateAround(customPivot.position, new Vector3(0, 0, 1), -90);
            //screen.SetActive(true);
            bridgeActive = true;
            yield return new WaitForSeconds(2);
            cutSceneDown.SetActive(false);

        }
    }
    IEnumerator LeaveButton()
    {
        //screen.SetActive(false);
        button.transform.position += new Vector3(0, 0.02f, 0);
        button.GetComponent<Renderer>().sharedMaterial = material[0];
        cutSceneUp.SetActive(true);
        //bridge.transform.RotateAround(customPivot.position, new Vector3(0, 0, 1), 90);
        bridgeActive = false;
        //screen.SetActive(true);
        yield return new WaitForSeconds(2);
        cutSceneUp.SetActive(false);
    }
}
