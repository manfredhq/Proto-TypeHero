using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[CreateAssetMenu(menuName = "Event/AItem Event")]
public class AItemEvent : ScriptableObject
{
    [SerializeField]
    private List<AItemListener> _listeners;

    public void Raise(AItem item)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(item);
        }
    }

    public void RegisterListener(AItemListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(AItemListener listener)
    {
        _listeners.Remove(listener);
    }
}
