using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUgui;
    public GameObject key;
    public String text;
    protected bool ShowOnce = false;
    public GameObject reactTo;
    public int waitSeconds = 5;
    protected int Attempts;
    public int showAgainInAttempts = 3;
    private Tween _tweenKey;
    private Tween _tweenUi;


    public Vector3 from = new Vector3(15, 15f, 15f);
    public Vector3 to = new Vector3(12f, 12f, 12f);
    public float uiFrom = 1.35f;
    public float uiTo = 1.2f;

    public void Start()
    {
        setKeyValue(text);
        HideKey();
    }

    public void setKeyValue(String key)
    {
        textMeshProUgui.text = key;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!ShowOnce)
        {
            if (other.gameObject.name == reactTo.name)
            {
                StartCoroutine(ShowKeyForSeconds());
            }
        }
        else if (Attempts >= showAgainInAttempts)
        {
            ShowOnce = false;
        }

        if (other.gameObject.name == reactTo.name) Attempts++;
    }

    protected IEnumerator ShowKeyForSeconds()
    {
        ShowKey();
        var i = 0;
        while (i < waitSeconds*2)
        {
            if(i%2==0){
                _tweenKey = key.transform.DOScale(to, 0.5f);
                _tweenUi = textMeshProUgui.transform.DOScale(uiTo, 0.5f);
            }
            else
            {
                _tweenKey = key.transform.DOScale(from, 0.5f);
                _tweenUi = textMeshProUgui.transform.DOScale(uiFrom, 0.5f);
            }
            
            yield return new WaitForSeconds(0.5f);
            i++;
        }
        
        ShowOnce = true;
        HideKey();
    }

    public void ShowKey()
    {
        key.SetActive(true);
    }

    public void HideKey()
    {
        if (_tweenKey != null)
        {
            _tweenKey.Kill();
        }

        if (_tweenUi != null)
        {
            _tweenUi.Kill();
        }

        key.SetActive(false);
    }


    private void OnDestroy()
    {
        _tweenKey.Kill();
        _tweenUi.Kill();
    }

    public void DoTweenStart()
    {
        key.transform.DOScale(from, 0.5f);
        textMeshProUgui.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
    }


    public void DoTweenEnd()
    {
        key.transform.DOScale(to, 0.5f);
        textMeshProUgui.transform.DOScale(new Vector3(1.35f, 1.35f, 1.35f), 0.5f);
    }
}