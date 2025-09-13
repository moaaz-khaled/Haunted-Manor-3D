using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public AudioSource Sound;

    public float fadeDuration = 0.5f;

    public void FadeToBlack()
    {
        StartCoroutine(Fade(0f, 1f));
        Sound.enabled = true;
    }

    public void FadeToClear() 
    {
        StartCoroutine(Fade(1f, 0f));
        Sound.enabled = false;
    }

    IEnumerator Fade(float fromAlpha, float toAlpha)
    {
        Color color = fadeImage.color;
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            color.a = Mathf.Lerp(fromAlpha, toAlpha, t);
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        color.a = toAlpha;
        fadeImage.color = color;
    }
}
