using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioClipFloatListener : MonoBehaviour
{
    [SerializeField]
    private AudioClipFloatEvent _event;

    [SerializeField]
    private UnityEvent<AudioClip,float> _onEventRaised;

    public void OnEventRaised(AudioClip aClip,float f)
    {
        _onEventRaised.Invoke(aClip,f);
    }

    private void OnEnable()
    {
        _event.RegisterListener(this);
    }

    private void OnDisable()
    {
        _event.UnregisterListener(this);
    }
}
