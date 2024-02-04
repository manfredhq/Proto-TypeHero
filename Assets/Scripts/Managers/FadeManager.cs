using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class FadeManager 
{
    public static IEnumerator FadeIn(TMP_Text text, float fadeInSpeed, int alphaMax = 255)
    {
        float alphaStep = fadeInSpeed * Time.deltaTime;
        while(!IsOpaque(text.color) && text.color.a * 255 <= alphaMax)
        {
            text.color += new Color(0, 0, 0, alphaStep);

            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator FadeIn(Image image, float fadeInSpeed, int alphaMax = 255)
    {
        float alphaStep = fadeInSpeed * Time.deltaTime;
        while (!IsOpaque(image.color) && image.color.a*255 <= alphaMax)
        {
            image.color += new Color(0, 0, 0, alphaStep);

            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator FadeIn(SpriteRenderer spriteRenderer, float fadeInSpeed, int alphaMax = 255)
    {
        float alphaStep = fadeInSpeed * Time.deltaTime;
        while (!IsOpaque(spriteRenderer.color) && spriteRenderer.color.a * 255 <= alphaMax)
        {
            spriteRenderer.color += new Color(0, 0, 0, alphaStep);

            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator FadeOut(TMP_Text text, float fadeOutSpeed)
    {
        float alphaStep = fadeOutSpeed * Time.deltaTime;
        while (!IsTransparent(text.color))
        {
            text.color -= new Color(0, 0, 0, alphaStep);

            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator FadeOut(Image image, float fadeOutSpeed)
    {
        float alphaStep = fadeOutSpeed * Time.deltaTime;
        while (!IsTransparent(image.color))
        {
            image.color -= new Color(0, 0, 0, alphaStep);

            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator FadeOut(SpriteRenderer spriteRenderer, float fadeOutSpeed)
    {
        float alphaStep = fadeOutSpeed * Time.deltaTime;
        while (!IsTransparent(spriteRenderer.color))
        {
            spriteRenderer.color -= new Color(0, 0, 0, alphaStep);

            yield return new WaitForEndOfFrame();
        }
    }

    public static bool IsOpaque(Color color)
    {
        return color.a >= 1;
    }
    public static bool IsTransparent(Color color)
    {
        return color.a <= 0;
    }
}
