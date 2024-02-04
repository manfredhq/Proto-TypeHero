using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerManager pManager;

    void OnGUI()
    {
        //This is used to get the key pressed by the user
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            if (Event.current.keyCode != KeyCode.None)
            {
                pManager.KeyPressed(Event.current.keyCode.ToString());

            }
        }
    }
}
