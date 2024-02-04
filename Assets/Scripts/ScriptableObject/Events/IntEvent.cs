using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[CreateAssetMenu(menuName = "Event/Int Event")]
public class IntEvent : ScriptableObject
{
    [SerializeField]
    private List<IntListener> _listeners;

    public void Raise(int i1)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(i1);
        }
    }

    public void RegisterListener(IntListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(IntListener listener)
    {
        _listeners.Remove(listener);
    }
}
