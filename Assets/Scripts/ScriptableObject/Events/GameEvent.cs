using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[CreateAssetMenu(menuName = "Event/Game Event")]
public class GameEvent : ScriptableObject
{
    [SerializeField]
    private List<GameListener> _listeners;

    public void Raise()
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised();
        }
    }

    public void RegisterListener(GameListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GameListener listener)
    {
        _listeners.Remove(listener);
    }
}
