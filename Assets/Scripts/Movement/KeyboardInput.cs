using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using ValueObjects;

public class KeyboardInput : MonoBehaviour
{
    public BoolObject showUi; 
    
    // Hier kann noch implementiert werden per Optionen die Tasten zu ändern
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            VirtualInputManager.Instance.MoveRight = true;
        }
        else
        {
            VirtualInputManager.Instance.MoveRight = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            VirtualInputManager.Instance.MoveLeft = true;
        }
        else
        {
            VirtualInputManager.Instance.MoveLeft = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            VirtualInputManager.Instance.Jump = true;
        }
        else
        {
            VirtualInputManager.Instance.Jump = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            VirtualInputManager.Instance.DoAction = true;
            
        }
        else
        {
            VirtualInputManager.Instance.DoAction = false;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            VirtualInputManager.Instance.ChangePlayer = true;
            
        }
        else
        {
            VirtualInputManager.Instance.ChangePlayer = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            VirtualInputManager.Instance.MoveUp = true;
            
        }
        else
        {
            VirtualInputManager.Instance.MoveUp = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            VirtualInputManager.Instance.MoveDown = true;
            
        }
        else
        {
            VirtualInputManager.Instance.MoveDown = false;
        }


    }

    //Menu reagiert nicht immer, wenn in fixedUpdate
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleBoolObject.Toggle(showUi);
        }
    }


}
