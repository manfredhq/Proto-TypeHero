using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[CreateAssetMenu(menuName = "Event/GO event")]
public class GOEvent : ScriptableObject
{
    [SerializeField]
    private List<GOListener> _listeners;

    public void Raise(GameObject go)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(go);
        }
    }

    public void RegisterListener(GOListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GOListener listener)
    {
        _listeners.Remove(listener);
    }
}
