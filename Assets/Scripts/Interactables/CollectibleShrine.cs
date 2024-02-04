using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CollectibleWordBank))]
public class CollectibleShrine : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;

    private string unlockWord;
    private CollectibleWordBank wordBank;

    [SerializeField]
    private float fadeSpeed = 1f;


    [SerializeField]
    private GameEvent healingShrineActivated;

    [Header("Audio")]
    [SerializeField]
    private AudioClipFloatEvent audioEvent;
    [SerializeField]
    private AudioClipInfo onCollectSound;
    private void Awake()
    {
        wordBank = GetComponent<CollectibleWordBank>();
        SetupWord(wordBank.GetRandomWord());
    }

    private void SetupWord(string word)
    {
        tmpText.text = word;
        unlockWord = word;
    }

    public void OnStringReceived(string s)
    {
        if (s.ToLower() == unlockWord.ToLower())
        {
            //Open the chest
            StartCoroutine(ActivateShrine());
        }
    }

    private IEnumerator ActivateShrine()
    {
        audioEvent.Raise(onCollectSound.clip, onCollectSound.targetVolume);
        StartCoroutine(FadeManager.FadeOut(tmpText, fadeSpeed));

        yield return new WaitUntil(() => FadeManager.IsTransparent(tmpText.color));

        //Raise an event and heal the player
        healingShrineActivated.Raise();
    }
}
