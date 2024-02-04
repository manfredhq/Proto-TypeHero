using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleWordBank : MonoBehaviour
{
    [SerializeField]
    private List<string> words = new List<string>();

    public string GetRandomWord()
    {
        return words[Random.Range(0, words.Count)].ToLower();
    }
}
