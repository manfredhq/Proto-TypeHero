using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public WordManager wordManager;

    public TextColoration textColoration;

    public PlayerStats playerStats;

    [SerializeField]
    private IntIntEvent wordFinishedEvent;

    [SerializeField]
    private IntEvent wordFinishedDamageEvent;

    [SerializeField]
    private BoolEvent canTypeChanged;

    [SerializeField]
    private StringEvent collectTypingFinished;

    [SerializeField]
    private bool canType = false;

    [SerializeField]
    public bool isInFight = false;

    [SerializeField]
    private GameObject creditMenu;
    [SerializeField]
    private BoolEvent onCreditStatusChannged;

    private TMP_Text tmpText;

    [Header("Audio")]
    [SerializeField]
    private AudioClipFloatEvent audioClipEvent;
    [SerializeField]
    private AudioClipInfo openFreeTypingAudioClip;
    [SerializeField]
    private AudioClipInfo wordEndAudioClip;

    private void Start()
    {
        textColoration = TextColoration.instance;
        tmpText = textColoration.GetComponent<TMP_Text>();
        playerStats = GetComponent<PlayerStats>();
        creditMenu.SetActive(false);
    }
    public void KeyPressed(string key)
    {
        if(!canType && key == "Escape")
        {
            creditMenu.SetActive(!creditMenu.activeInHierarchy);
            onCreditStatusChannged.Raise(creditMenu.activeInHierarchy);
        }
        if (!canType && key != "Space" || GameManager.isLevelEnded || creditMenu.activeInHierarchy) { return; }
        else if(key == "Space" && !isInFight)
        {
            canType = !canType;
            canTypeChanged.Raise(canType);

            if (!canType)
            {
                //Raise the event with the word written in params
                collectTypingFinished.Raise(tmpText.text);
                tmpText.text = "";
            }
            else
            {
                audioClipEvent.Raise(openFreeTypingAudioClip.clip, openFreeTypingAudioClip.targetVolume);
            }

        }
        key = key.ToLower();

        if (isInFight)
        {
            FightTyping(key);
        }
        else
        {
            CollectTyping(key);
        }
    }

    private void FightTyping(string key)
    {
        if (!isInFight) return;

        if (key == "space" && (textColoration.IsLastLetterOfLine() || textColoration.IsLastWordOfLine()))
        {
            int goodLettersInCurrentWord = textColoration.GoodLettersAmountInCurrentWord();
            int wrongLettersInCurrentWord = textColoration.WrongLettersAmountInCurrentWord();
            textColoration.NextLine();
            if (textColoration.IsLastLine())
            {
                wordManager.GenerateWords();
            }
            wordFinishedEvent.Raise(goodLettersInCurrentWord, wrongLettersInCurrentWord);
            //send damage to inflict on enemies
            wordFinishedDamageEvent.Raise(CalculateDamage(goodLettersInCurrentWord));
            audioClipEvent.Raise(wordEndAudioClip.clip, wordEndAudioClip.targetVolume);
            return;
        }
        else if (key == "space")
        {
            int goodLettersInCurrentWord = textColoration.GoodLettersAmountInCurrentWord();
            int wrongLettersInCurrentWord = textColoration.WrongLettersAmountInCurrentWord();
            textColoration.NextWord();
            wordFinishedEvent.Raise(goodLettersInCurrentWord, wrongLettersInCurrentWord);
            //send damage to inflict on enemies
            wordFinishedDamageEvent.Raise(CalculateDamage(goodLettersInCurrentWord));
            audioClipEvent.Raise(wordEndAudioClip.clip, wordEndAudioClip.targetVolume);
        }
        //If the whole text is colored
        if (textColoration.currentLetterIndex == textColoration.GetText().Length)
        {
            
                //Finish the word
            if (key == "space")
            {
                //Next word to appear
                wordFinishedEvent.Raise(textColoration.greenLetters.Count, textColoration.redLetters.Count);
            }
            
            //Remove a colored letter
            else if (key == "backspace")
            {
                textColoration.RemoveLastLetterColored();
            }
        }
        else
        {
            //We get the next letter of the word and the key pressed by the user and lower both of them
            string goodLetter = textColoration.GetText()[textColoration.currentLetterIndex].ToString();
            goodLetter = goodLetter.ToLower();
            if(goodLetter == " " && key != "space")
            {
                return;
            }

            if (key == goodLetter)
            {
                textColoration.ColorNextLetterInGreen();
            }
            else if (key == "backspace")
            {
                textColoration.RemoveLastLetterColored();
            }
            else
            {
                textColoration.ColorNextLetterInRed();
            }
        }
    }

    private void CollectTyping(string key)
    {
        if (key == "backspace" && tmpText.text.Length >= 1)
        {
            tmpText.text = tmpText.text.Substring(0, tmpText.text.Length - 1);
        }
        else if (key.Length > 1)
        {
            return;
        }
        else
        {
            // block beyond 30 characters
            if (tmpText.text.Length < 30)
            {
                tmpText.text += key;
            }
        }
    }

    public void CanType()
    {
        canType = true;
    }

    public void CannotType()
    {
        canType = false;
    }

    public void IsInFight(bool inFight)
    {
        isInFight = inFight;
    } 

    public int CalculateDamage(int goodLettersIn)
    {
        int damageDealt = 0;

        if(goodLettersIn >= 1)
        {
            damageDealt = (goodLettersIn * playerStats.GetBaseAttack()) + playerStats.GetAttackPower();
        } else
        {
            //if all letters in word are wrong
        }
        return damageDealt;
    }
}
