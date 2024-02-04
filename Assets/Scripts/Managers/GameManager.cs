using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Fight Popup")]
    [SerializeField]
    private TMP_Text fightPopUp;
    [SerializeField]
    private Image imageBlackBox;
    [SerializeField]
    private float timeFadeInFightPopUp = 1f;
    [SerializeField]
    private float timeVisibleFightPopUp = 1f;
    [SerializeField]
    private float timeFadeOutFightPopUp = 1f;
    [SerializeField]
    private GameEvent fightPopupFinishedEvent;

    public static bool isLevelEnded = false;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AnimationClip openAnim;

    [SerializeField]
    private GameObject currentFight;

    private Coroutine blackboxCurrentCoroutine = null;

    private void Start()
    {
        isLevelEnded = false;
    }

    public void ReloadScene()
    {
        isLevelEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnStartFight(GameObject _currentFight)
    {
        currentFight = _currentFight;
        StartCoroutine(FightPopupManage());
        animator.Play("Open");
        /*StopCoroutine(BlackBoxDespawn());
        if (blackboxCurrentCoroutine != null)
            StopCoroutine(blackboxCurrentCoroutine);
        StartCoroutine(BlackBoxSpawn());*/
    }

    public IEnumerator FightPopupManage()
    {
        IEnumerator fadeInCoroutine = FadeManager.FadeIn(fightPopUp, timeFadeInFightPopUp);
        StartCoroutine(fadeInCoroutine);
        yield return new WaitUntil(() => FadeManager.IsOpaque(fightPopUp.color));

        yield return new WaitForSeconds(timeVisibleFightPopUp);

        IEnumerator fadeOutCoroutine = FadeManager.FadeOut(fightPopUp, timeFadeOutFightPopUp);
        StartCoroutine(fadeOutCoroutine);
        yield return new WaitUntil(() => FadeManager.IsTransparent(fightPopUp.color));

        fightPopupFinishedEvent.Raise();
    }

    public IEnumerator BlackBoxSpawn()
    {
        //using same spawn time as fight popup because we need box to be ready when fight pop up is gone anyway
        IEnumerator fadeInCoroutine = FadeManager.FadeIn(imageBlackBox, timeFadeInFightPopUp);
        blackboxCurrentCoroutine = StartCoroutine(fadeInCoroutine);
        yield return new WaitUntil(() => FadeManager.IsOpaque(imageBlackBox.color));
    }

    public IEnumerator BlackBoxDespawn()
    {
        IEnumerator fadeOutCoroutine = FadeManager.FadeOut(imageBlackBox, timeFadeOutFightPopUp);
        blackboxCurrentCoroutine = StartCoroutine(fadeOutCoroutine);
        yield return new WaitUntil(() => FadeManager.IsTransparent(imageBlackBox.color));
    }


    public void OnFightEnded()
    {
        Destroy(currentFight);
        /*StartCoroutine(BlackBoxDespawn());*/
        animator.Play("Close");
    }

    public void OnCanTypeChanged(bool canTypeValue)
    {
        if (isLevelEnded) return;

        switch (canTypeValue)
        {
            case true:
                animator.Play("Open");
                /*
                StopCoroutine(BlackBoxDespawn());
                if(blackboxCurrentCoroutine != null)
                    StopCoroutine(blackboxCurrentCoroutine);
                StartCoroutine(BlackBoxSpawn());*/
                break;
            case false:
                animator.Play("Close");/*
                StopCoroutine(BlackBoxSpawn());
                if (blackboxCurrentCoroutine != null)
                    StopCoroutine(blackboxCurrentCoroutine);
                StartCoroutine(BlackBoxDespawn());*/
                break;
        }
    }

    public void OnLevelEnded()
    {
        isLevelEnded = true;
    }
}

