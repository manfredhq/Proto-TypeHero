using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseUIManager : MonoBehaviour
{
    private Canvas loseUI;

    private void Start()
    {
        loseUI = GetComponent<Canvas>();
        loseUI.enabled = false;
    }
    public void OnLevelEnded()
    {
        loseUI.enabled = true;
    }
}
