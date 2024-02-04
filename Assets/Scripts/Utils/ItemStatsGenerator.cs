using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatsGenerator
{
    //We create a new stat of type T, this type need to implement AStats
    //This stat will have its value set to the float given
    public static T GenerateNewStat<T>(float statValue) where T : AStats
    {
        T stat = ScriptableObject.CreateInstance<T>();
        stat.Init(statValue);
        return stat;
    }

    //We create a new stat of type T, this type need to implement AStats
    //This stat will have its value set between the two floats given
    public static T GenerateNewStat<T>(float minValueInclusive, float maxValueExclusive) where T : AStats
    {
        T stat = ScriptableObject.CreateInstance<T>();

        //We get a float with only one decimal number
        float statValue = Mathf.Round(Random.Range(minValueInclusive, maxValueExclusive) * 10) / 10;

        stat.Init(statValue);
        return stat;
    }
}
