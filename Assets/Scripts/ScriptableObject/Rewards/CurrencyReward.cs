using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CurrencyReward : IReward
{
    [SerializeField]
    private int currencyAmount = 10;

    [SerializeField]
    private IntEvent earnCurrencyEvent;
    public override void EarnReward()
    {
        Debug.Log($"EarnCurrency: {name}, amount: {currencyAmount}");
        earnCurrencyEvent?.Raise(currencyAmount);
    }
}
