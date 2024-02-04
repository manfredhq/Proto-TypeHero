using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamManager : MonoBehaviour
{

    [SerializeField]
    private List<FightListSpawn> spawnPoints = new List<FightListSpawn>();

    private List<List<GameObject>> enemiesInstance = new List<List<GameObject>>();

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameEvent fightEndedEvent;

    private int currentFight = 0;

    [SerializeField]
    private GameEvent levelEndedEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    public void OnWordEnded(int goodLetters, int badLetters)
    {
        // do ouais
    }

    public void InflictDamage(int damageDealt)
    {
        enemiesInstance[currentFight][0].GetComponent<Enemy>().TakeDamage(damageDealt);

        if (enemiesInstance[currentFight].Count == 0 && currentFight == enemiesInstance.Count - 1)
        {
            fightEndedEvent.Raise();
        }

        else if (enemiesInstance[currentFight].Count == 0)
        {
            currentFight++;
            fightEndedEvent.Raise();
        }
    }

    private void SpawnEnemies()
    {
        foreach (var spawns in spawnPoints)
        {
            List<GameObject> enemyTeam = new List<GameObject>();
            foreach (var spawn in spawns.spawnPoints)
            {
                GameObject instance = Instantiate(enemyPrefab, spawn);
                enemyTeam.Add(instance);
                instance.GetComponent<Enemy>().enabled = false;
            }
            enemiesInstance.Add(enemyTeam);
        }
    }

    public void OnEnemyDeath(GameObject go)
    {
        enemiesInstance[currentFight].Remove(go);
        Destroy(go);
    }

    public void OnFightStart()
    {
        foreach (var enemies in enemiesInstance[currentFight])
        {
            enemies.GetComponent<Enemy>().enabled = true;
        }
    }
}
