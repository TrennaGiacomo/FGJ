using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public float fadeDuration;
    public Image fadeImage;

    public void Fade(Action onFinish)
    {
        StartCoroutine(FadeCoroutine(onFinish));
    }

    IEnumerator FadeCoroutine(Action onFinish)
    {
        float a = 0;
        fadeImage.color = Color.clear;
        while (a < 1)
        {
            DontDestroyOnLoadMusic.musicSource.volume = 1f - a;
            
            a += (1 / fadeDuration) * Time.deltaTime;
            fadeImage.color = new(0, 0, 0, a);
            yield return new WaitForEndOfFrame();
        }

        DontDestroyOnLoadMusic.musicSource.Stop();

        yield return new WaitForSeconds(0.5f);

        onFinish.Invoke();
    }
}
