using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FightRewards))]
[RequireComponent(typeof(FightListSpawn))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(GOListener))]
[RequireComponent(typeof(GameListener))]
public class FightManager : MonoBehaviour
{

    [SerializeField]
    private List<MonoBehaviour> componentToActivateWhenFightStart = new List<MonoBehaviour>();
    public void OnStartFight(GameObject fight)
    {
        if(fight == gameObject)
        {
            foreach (var component in componentToActivateWhenFightStart)
            {
                component.enabled = true;
            }
        }
    }
}
