using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[CreateAssetMenu(menuName ="Event/String Event")]
public class StringEvent : ScriptableObject
{
    [SerializeField]
    private List<StringListener> _listeners;

    public void Raise(string s)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(s);
        }
    }

    public void RegisterListener(StringListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(StringListener listener)
    {
        _listeners.Remove(listener);
    }
}
