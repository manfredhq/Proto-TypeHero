using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackboxController : MonoBehaviour
{
    [SerializeField]
    private Image img;

    private Coroutine currentCoroutine = null;
    public void FadeIn()
    {
        if(currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(FadeManager.FadeIn(img,1f));
    }

    public void FadeOut()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(FadeManager.FadeOut(img, 1f));
    }
}
