using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private GameObject playerInstance;

    // Start is called before the first frame update
    void Start()
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint);
    }

    public void OnDamageTaken(int amount)
    {
        playerInstance.GetComponent<PlayerStats>().TakeDamage(amount);
    }

    public void OnLevelEnded()
    {
        //bien joué mec
    }
}
