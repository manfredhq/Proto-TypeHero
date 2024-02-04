using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsText : MonoBehaviour
{
    public string baseString = "";
    public string endString = "";

    public TMP_Text text;

    public void ChangeSting(int value)
    {
        text.text = $"{baseString} {value} {endString}";
    }

    public void ChangeString(string value)
    {
        text.text = $"{baseString} {value} {endString}";
    }
}
