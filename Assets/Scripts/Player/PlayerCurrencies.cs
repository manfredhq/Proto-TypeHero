using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencies : MonoBehaviour
{
    [SerializeField]
    private int gold = 0;

    [SerializeField]
    private IntEvent OnGoldChanged;

    [Header("Audio")]
    [SerializeField]
    private AudioClipFloatEvent soundEvent;
    [SerializeField]
    private AudioClipInfo earnGoldSound;

    public void EarnGold(int amount)
    {
        gold += amount;
        soundEvent.Raise(earnGoldSound.clip, earnGoldSound.targetVolume);
        OnGoldChanged.Raise(gold);
    }
}
