using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowGhost : MonoBehaviour
{
    public Image ImageGhost;
    public AudioSource Sound;

    public float fadeDuration = 0.5f;

    public void ShowGhostEffect()
    {
        StartCoroutine(Fade(0f, 1f));
        Sound.enabled = true;
    }

    public void HideGhostEffect() 
    {
        StartCoroutine(Fade(1f, 0f));
        Sound.enabled = false;
    }

    IEnumerator Fade(float fromAlpha, float toAlpha)
    {
        Color color = ImageGhost.color;
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            color.a = Mathf.Lerp(fromAlpha, toAlpha, t);
            ImageGhost.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        color.a = toAlpha;
        ImageGhost.color = color;
    }
}
