using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using ValueObjects;

/**
 * Verändert die Exposed Values der einzelnen AudiomixerGruppen
 */
public class setVolume : MonoBehaviour
{
    private String[] mixerGroupVolumeArray = {"Master Volume", "FX Volume","Music Volume"};
    public String mixerGroup;
    public AudioMixer mixer;
    public FloatObject master;
    public FloatObject music;
    public FloatObject fx;

    private void Awake()
    {
        
        switch (mixerGroup)
        {
            case "Music Volume":
                mixer.SetFloat(getMixerGroup(mixerGroup), Mathf.Log10(music.RuntimeValue) * 20);
                gameObject.GetComponent<Slider>().value = music.RuntimeValue;
                break;
            case "FX Volume":
                mixer.SetFloat(getMixerGroup(mixerGroup),Mathf.Log10(fx.RuntimeValue) * 20 );
                gameObject.GetComponent<Slider>().value = fx.RuntimeValue;
                break;
            case "Master Volume":
                mixer.SetFloat(getMixerGroup(mixerGroup), Mathf.Log10(master.RuntimeValue) * 20);
                gameObject.GetComponent<Slider>().value = master.RuntimeValue;
                break;
            default:
                break;
        }
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat(getMixerGroup(mixerGroup), Mathf.Log10(sliderValue) * 20);
        switch (getMixerGroup(mixerGroup))
        {
            case "Music Volume":
                music.RuntimeValue = sliderValue;
                break;
            case "FX Volume":
                fx.RuntimeValue = sliderValue;
                break;
            default:
                master.RuntimeValue = sliderValue;
                break;
        }
    }

    public String getMixerGroup(String mixerGroupName)
    {
        foreach (String name in mixerGroupVolumeArray)
        {
            if (mixerGroupName.Equals(name))
            {
                return name;
            }
        }
        Debug.LogError("Sound "+ mixerGroupName + " not found!");
        return null;
    }
}
