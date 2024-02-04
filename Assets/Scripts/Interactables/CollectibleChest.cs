using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CollectibleWordBank))]
[RequireComponent(typeof(ChestContent))]
public class CollectibleChest : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;

    private string unlockWord;
    private CollectibleWordBank wordBank;

    [SerializeField]
    private float fadeSpeed = 1f;

    private SpriteRenderer spriteRenderer;
    private ChestContent chestContent;

    [SerializeField]
    private AudioClipFloatEvent audioClipFloatEvent;
    [SerializeField]
    private AudioClipInfo audioClip;
    private void Awake()
    {
        wordBank = GetComponent<CollectibleWordBank>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        chestContent = GetComponent<ChestContent>();
        SetupWord(wordBank.GetRandomWord());
    }

    public void OnStringReceived(string s)
    {
        if(s.ToLower() == unlockWord.ToLower())
        {
            //Open the chest
            StartCoroutine(Unlock());
            audioClipFloatEvent.Raise(audioClip.clip, audioClip.targetVolume);
        }
    }

    private void SetupWord(string word)
    {
        tmpText.text = word;
        unlockWord = word;
    }

    private IEnumerator Unlock()
    {
        DropLoot();

        StartCoroutine(FadeManager.FadeOut(spriteRenderer, fadeSpeed));
        StartCoroutine(FadeManager.FadeOut(tmpText, fadeSpeed));
        yield return new WaitUntil(() => FadeManager.IsTransparent(spriteRenderer.color));
        Destroy(gameObject);
    }

    private void DropLoot()
    {
        List<AItem> loot = chestContent.GetRandomLoot();
        Vector3 mostLeftPos = transform.position;
        Vector3 mostRightPos = transform.position;
        mostLeftPos.x -= loot[0].inventorySprite.bounds.extents.x * 6;
        for (int i = 0; i < loot.Count; i++)
        {
            if(i%2 == 0)
            {
                CollectibleLoot collectibleLoot = Instantiate(loot[i].IGPrefab, mostRightPos, Quaternion.identity).GetComponent<CollectibleLoot>();
                collectibleLoot.GetComponent<SpriteRenderer>().sprite = loot[i].inventorySprite;
                collectibleLoot.correspondingAItem = loot[i];
                mostRightPos.x += loot[i].inventorySprite.bounds.extents.x * collectibleLoot.transform.localScale.x * 2;
            }
            else
            {
                CollectibleLoot collectibleLoot = Instantiate(loot[i].IGPrefab, mostLeftPos, Quaternion.identity).GetComponent<CollectibleLoot>();
                collectibleLoot.GetComponent<SpriteRenderer>().sprite = loot[i].inventorySprite;
                collectibleLoot.correspondingAItem = loot[i];
                mostLeftPos.x -= loot[i].inventorySprite.bounds.extents.x * collectibleLoot.transform.localScale.x * 2;
            }
        }
        
    }
}
