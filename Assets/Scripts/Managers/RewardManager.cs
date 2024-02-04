using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private List<Reward> rewards = new List<Reward>();

    
    public void GetRandomReward()
    {
        Reward reward = rewards[Random.Range(0, rewards.Count)];
        reward.GetRewards();
    }
}
