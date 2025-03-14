using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeDuration = 2f;
    public float displayTime = 4f; 

    void Start()
    {
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, 0); 
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        yield return StartCoroutine(FadeInText());  
        yield return new WaitForSeconds(displayTime); 
        yield return StartCoroutine(FadeOutText()); 
    }

    IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        Color textColor = textMeshPro.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            textMeshPro.color = textColor;
            yield return null;
        }
    }

    IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color textColor = textMeshPro.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            textMeshPro.color = textColor;
            yield return null;
        }

        textMeshPro.gameObject.SetActive(false); 
    }
}
