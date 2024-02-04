using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private string openInventoryString = "inventory";

    [SerializeField]
    private string closeInventoryString = "close";


    [SerializeField]
    private Image panelImage;

    [SerializeField]
    private GameObject layoutObject;

    [SerializeField]
    private GameEvent openInventoryEvent;

    [SerializeField]
    private GameEvent closeInventoryEvent;

    [SerializeField]
    private GameObject inventoryItemPrefab;

    [SerializeField]
    private PlayerInventory inventory;

    [SerializeField]
    private List<Image> instantiatedItems = new List<Image>();

    [SerializeField]
    private AItemEvent equipEvent;


    [Header("Audio")]
    [SerializeField]
    private AudioClipFloatEvent audioEvent;
    [SerializeField]
    private AudioClipInfo inventoryOpenCloseAudio;

    public void OnCollectTypingFinished(string s)
    {
        StopAllCoroutines();
        if (s.ToLower() == openInventoryString.ToLower())
        {
            instantiatedItems = new List<Image>();
            openInventoryEvent.Raise();
            StartCoroutine(FadeManager.FadeIn(panelImage, 1f));
            audioEvent.Raise(inventoryOpenCloseAudio.clip, inventoryOpenCloseAudio.targetVolume);
            ShowItemsInInventory();
        }
        else if (s.ToLower() == closeInventoryString.ToLower())
        {
            closeInventoryEvent.Raise();
            StartCoroutine(FadeManager.FadeOut(panelImage, 1f));
            audioEvent.Raise(inventoryOpenCloseAudio.clip, inventoryOpenCloseAudio.targetVolume);
            StartCoroutine(FadeOutItems(panelImage));
        }
    }

    private IEnumerator FadeOutItems(Image panelImage)
    {
        do
        {
            foreach (var item in instantiatedItems)
            {
                item.color = panelImage.color;
            }
            yield return null;
        } while (!FadeManager.IsTransparent(panelImage.color));

        foreach (var item in instantiatedItems)
        {
            Destroy(item.gameObject);
        }
    }

    private void ShowItemsInInventory()
    {
        foreach (var item in inventory.GetItems())
        {
            GameObject inventoryItem = Instantiate(inventoryItemPrefab, layoutObject.transform);
            Image[] inventoryItemImages = inventoryItem.GetComponentsInChildren<Image>();
            Image inventoryItemImage = inventoryItemImages[inventoryItemImages.Length - 1];
            inventoryItemImage.sprite = item.inventorySprite;
            instantiatedItems.Add(inventoryItemImages[0]);
            StartCoroutine(FadeManager.FadeIn(inventoryItemImages[0], 1f));

            Button itemButton = inventoryItem.GetComponent<Button>();
            SetButtonListener(itemButton,item);
        }
    }

    public void RefreshInventory()
    {
        if (!FadeManager.IsTransparent(panelImage.color)) { 
            foreach (var item in instantiatedItems)
            {
                Destroy(item.gameObject);
            }
            instantiatedItems.RemoveAll((img) => {return img.GetComponentsInChildren<Image>() == null; });
            instantiatedItems.Clear();
            ShowItemsInInventory();
        }
    }

    private void SetButtonListener(Button button, AItem item)
    {
        button.onClick.AddListener(() => equipEvent.Raise(item));
    }
}
