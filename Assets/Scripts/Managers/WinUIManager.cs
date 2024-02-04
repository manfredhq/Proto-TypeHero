using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class WinUIManager : MonoBehaviour
{
    private Canvas winUI;

    private void Start()
    {
        winUI = GetComponent<Canvas>();
        winUI.enabled = false;
    }

    public void OnLevelEnded()
    {
        winUI.enabled = true;
    }
}
