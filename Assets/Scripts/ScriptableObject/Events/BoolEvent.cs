using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[CreateAssetMenu(menuName = "Event/Bool Event")]
public class BoolEvent : ScriptableObject
{
    [SerializeField]
    private List<BoolListener> _listeners;

    public void Raise(bool b)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(b);
        }
    }

    public void RegisterListener(BoolListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(BoolListener listener)
    {
        _listeners.Remove(listener);
    }
}
