using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Stat/Vitality")]
public class ItemVitality : AStats
{
    public override void ApplyStats(PlayerStats pStats)
    {
        pStats.ChangeVitality((int)bonusStats);
    }

    public override void RemoveStats(PlayerStats pStats)
    {

        pStats.ChangeVitality(-(int)bonusStats);
    }
}
