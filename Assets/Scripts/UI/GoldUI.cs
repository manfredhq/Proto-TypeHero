using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    private TMP_Text goldText;

    private void Awake()
    {
        goldText = GetComponent<TMP_Text>();
    }
    public void OnGoldChanged(int newAmount)
    {
        goldText.text = $"{newAmount}";
    }
}
