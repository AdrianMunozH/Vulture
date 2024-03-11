using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeQuality : MonoBehaviour
{
    public Dropdown dropdown;
    private void Awake()
    {
        dropdown.SetValueWithoutNotify(QualitySettings.GetQualityLevel());
    }

    public void HandleInputData(int val){
        QualitySettings.SetQualityLevel(val,true);
    }
}
