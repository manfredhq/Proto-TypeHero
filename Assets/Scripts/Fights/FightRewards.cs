using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRewards : MonoBehaviour
{
    public List<Reward> rewards = new List<Reward>();

    public void OnFightEnd()
    {
        Reward reward = rewards[Random.Range(0, rewards.Count)];
        reward.GetRewards();
    }
}
