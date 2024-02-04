using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(CollectibleWordBank))]
public class CollectibleLoot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;

    private string unlockWord;
    private CollectibleWordBank wordBank;

    [SerializeField]
    private float fadeSpeed = 1f;

    [SerializeField]
    private AItemEvent itemEarnedEvent;

    public AItem correspondingAItem;

    private SpriteRenderer spriteRenderer;

    [Header("Audio")]
    [SerializeField]
    private AudioClipFloatEvent audioEvent;
    [SerializeField]
    private AudioClipInfo onPickItem;

    private void Awake()
    {
        wordBank = GetComponent<CollectibleWordBank>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            StartCoroutine(EarnItem());
        }
    }

    private IEnumerator EarnItem()
    {
        audioEvent.Raise(onPickItem.clip, onPickItem.targetVolume);
        StartCoroutine(FadeManager.FadeOut(spriteRenderer, fadeSpeed));
        StartCoroutine(FadeManager.FadeOut(tmpText, fadeSpeed));

        //Raise the event to earn the item
        itemEarnedEvent.Raise(correspondingAItem);

        yield return new WaitUntil(() => FadeManager.IsTransparent(spriteRenderer.color));

        Destroy(gameObject);
    } 
}
