using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Test
    private bool _moveRight;
    private bool _moveLeft;
    private bool _jump;
    
    private bool _moveUp;
    private bool _moveDown;
    private bool _doAction;
    
    public bool MoveRight
    {
        get => _moveRight;
        set => _moveRight = value;
    }

    public bool MoveLeft
    {
        get => _moveLeft;
        set => _moveLeft = value;
    }

    public bool Jump
    {
        get => _jump;
        set => _jump = value;
    }
    

    public float moveSpeed;
    

    
    public bool MoveUp
    {
        get => _moveUp;
        set => _moveUp = value;
    }
    public bool MoveDown
    {
        get => _moveDown;
        set => _moveDown = value;
    }
    
    
    public float jumpForce;
    private Rigidbody rigid;
    public Rigidbody Rigidbody
    {
        get
        {
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
            }
            return rigid;
        }
    }

    public bool DoAction { get => _doAction; set => _doAction = value; }

    public float faceAngle = 90f;
    
}
