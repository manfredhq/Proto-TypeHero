using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<string> wordsBank = new List<string>();

    [SerializeField]
    PlayerManager playerManager;



    public void ChangeWord()
    {
        GenerateWords();
    }

    public void GenerateWords(int amountOfWords = 100)
    {
        if (!playerManager.isInFight) { return; }
        string words = "";
        for (int i = 0; i < amountOfWords; i++)
        {
            var wordIndex = Random.Range(0, wordsBank.Count);
            words += wordsBank[wordIndex] + " " ;
           /* playerManager.textColoration.SetText(wordsBank[wordIndex]);

            playerManager.textColoration.OnChangeWord();*/
        }
        playerManager.textColoration.SetText(words);

        //playerManager.textColoration.OnChangeWord();
        
    }
}
