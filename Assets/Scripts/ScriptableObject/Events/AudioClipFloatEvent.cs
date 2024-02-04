using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
[CreateAssetMenu(menuName = "Event/Audio Clip Float Event")]
public class AudioClipFloatEvent : ScriptableObject
{
    [SerializeField]
    private List<AudioClipFloatListener> _listeners;

    public void Raise(AudioClip aClip,float f)
    {
        UnityEngine.Debug.Log($"{new StackFrame(1).GetMethod().Name} raised the event: {name}");
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(aClip,f);
        }
    }

    public void RegisterListener(AudioClipFloatListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(AudioClipFloatListener listener)
    {
        _listeners.Remove(listener);
    }
}
