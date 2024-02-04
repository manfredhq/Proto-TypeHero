using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reward/New Reward")]
public class Reward : ScriptableObject
{
    public List<IReward> rewards = new List<IReward>();

    public void GetRewards()
    {
        foreach (var reward in rewards)
        {
            reward?.EarnReward();
        }
    }
}
