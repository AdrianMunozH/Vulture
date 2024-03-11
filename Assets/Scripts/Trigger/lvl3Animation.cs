using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3Animation : MonoBehaviour
{
    public GameObject _gameObject;
    // Start is called before the first frame update
    
    void Start()
    {
        StartCoroutine("rotatePos");
        
        
        Debug.Log("start lvl3 Animation Moleboy");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator rotatePos()
    {
        yield return new WaitForSeconds(3f);
        _gameObject.GetComponent<ExtPlayerMovement>().MoveLeft = true;
        yield return new WaitForSeconds(0.25f);
        _gameObject.GetComponent<ExtPlayerMovement>().MoveLeft = false;
        _gameObject.GetComponent<Animator>().SetBool("laying",true);
    }
    
}
