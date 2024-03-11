using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VirtualInputManager : Singleton<VirtualInputManager>
{
    public bool MoveRight;
    public bool MoveLeft;
    public bool Jump;
    public bool DoAction;
    public bool ChangePlayer;
    public bool MoveUp;
    public bool MoveDown;
}
