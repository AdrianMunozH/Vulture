using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        //Wait for 6 seconds
        yield return new WaitForSeconds(6);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
