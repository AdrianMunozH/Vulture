using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using ValueObjects;

public class HintControllerAbyss : HintController
{
    public IntObject count;
    public TextMeshProUGUI textMeshProUgui1;
    public GameObject key1;
    private Tween _tweenKey1;
    private Tween _tweenUi1;
    public Vector3 from1;
    public Vector3 to1;
    public float fromUi1;
    public float toUi1;
    public String text1;
    public GameObject reactTo1;
    
    public void Start()
    {
        setKeyValue(text);
        setKeyValue1(text1);
        HideKey();
        HideKey1();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Brueckentrigger")
        {
            if (count.RuntimeValue % 4 == 0  && count.RuntimeValue != 0)
            {
                if (other.gameObject.name == reactTo.name || other.gameObject.name == reactTo1.name)
                {
                    StartCoroutine(ShowKeyForSeconds());
                    StartCoroutine(ShowKeyForSeconds1());
                }
            } else if (Attempts >= showAgainInAttempts)
            {
                ShowOnce = false;
            }
            if (other.gameObject.name == reactTo.name || other.gameObject.name == reactTo1.name) count.RuntimeValue++;
        }
    }
    
    protected IEnumerator ShowKeyForSeconds1()
    {
        ShowKey1();
        var i = 0;
        while (i < waitSeconds*2)
        {
            if(i%2==0){
                _tweenKey1 = key1.transform.DOScale(to1, 0.5f);
                _tweenUi1 = textMeshProUgui1.transform.DOScale(toUi1, 0.5f);
            }
            else
            {
                _tweenKey1 = key1.transform.DOScale(from1, 0.5f);
                _tweenUi1 = textMeshProUgui1.transform.DOScale(fromUi1, 0.5f);
            }
            
            yield return new WaitForSeconds(0.5f);
            i++;
        }
        
        ShowOnce = true;
        HideKey1();
    }
    
    
    public void HideKey1()
    {
        if (_tweenKey1 != null)
        {
            _tweenKey1.Kill();
        }

        if (_tweenUi1 != null)
        {
            _tweenUi1.Kill();
        }

        key1.SetActive(false);
    }

    public void setKeyValue1(String key1)
    {
        textMeshProUgui1.text = key1;
    }
    
    private void OnDestroy()
    {
        _tweenKey1.Kill();
        _tweenUi1.Kill();
    }
    
    public void ShowKey1()
    {
        key1.SetActive(true);
    }

}
