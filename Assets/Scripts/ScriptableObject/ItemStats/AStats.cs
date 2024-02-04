using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStats : ScriptableObject
{
    public float bonusStats;

    public void Init(float bStats)
    {
        bonusStats = bStats;
    }
    public virtual void ApplyStats(PlayerStats pStats)
    {
        throw new System.Exception("Apply stats not implemented");
    }

    public virtual void RemoveStats(PlayerStats pStats)
    {
        throw new System.Exception("Remove stats not implemented");
    }
}
