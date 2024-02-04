using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item Stat/Attack Power")]
public class ItemAttackPower : AStats
{
    public override void ApplyStats(PlayerStats pStats)
    {
        pStats.ChangeAttackPower((int)bonusStats);
    }

    public override void RemoveStats(PlayerStats pStats)
    {

        pStats.ChangeAttackPower(-(int)bonusStats);
    }
}
