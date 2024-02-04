using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[CreateAssetMenu(menuName = "Event/Int Int event")]
public class IntIntEvent : ScriptableObject
{
    [SerializeField]
    private List<IntIntListener> _listeners;

    public void Raise(int i1, int i2)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(i1, i2);
        }
    }

    public void RegisterListener(IntIntListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(IntIntListener listener)
    {
        _listeners.Remove(listener);
    }
}
