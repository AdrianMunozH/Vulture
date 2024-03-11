using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Typing : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string text;
    public int startDelayTyping = 0;
    public float typeDelayFrom = 0f;
    public float typeDelayTo = 0.25f;
    public int startDelayImageFloating;
    public GameObject menuBackground;

    public GameObject enableButtons;

    void Awake () 
    {
        text = textMeshPro.text;
        textMeshPro.text = "";

        StartCoroutine ("PlayText");
        StartCoroutine("FadeInBackground");
    }

    IEnumerator PlayText()
    {
        yield return new WaitForSeconds(startDelayTyping);
        foreach (char c in text) 
        {
            textMeshPro.text += c;
            yield return new WaitForSeconds (Random.Range(typeDelayFrom,typeDelayTo));
        }
    }

    IEnumerator FadeInBackground()
    {
        yield return new WaitForSeconds(startDelayImageFloating);

        Image image = menuBackground.GetComponent<Image>();
        var tempColor = image.color;
        float end = 0.3f;
        float start = 0f;

        while (start < end)
        {
            start += 0.02f;
            yield return new WaitForSeconds(0.1f);
            tempColor.a = start;
            image.color = tempColor;
        }

        foreach (Transform child in enableButtons.transform)
        {
            yield return new WaitForSeconds(0.25f);
            child.gameObject.SetActive(true);
        }

    }
}
