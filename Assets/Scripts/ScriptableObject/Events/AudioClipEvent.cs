using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
[CreateAssetMenu(menuName = "Event/Audio Clip Event")]
public class AudioClipEvent : ScriptableObject
{
    [SerializeField]
    private List<AudioClipListener> _listeners;

    public void Raise(AudioClip aClip)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(aClip);
        }
    }

    public void RegisterListener(AudioClipListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(AudioClipListener listener)
    {
        _listeners.Remove(listener);
    }
}
