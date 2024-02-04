using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioClipListener : MonoBehaviour
{
    [SerializeField]
    private AudioClipEvent _event;

    [SerializeField]
    private UnityEvent<AudioClip> _onEventRaised;

    public void OnEventRaised(AudioClip aClip)
    {
        _onEventRaised.Invoke(aClip);
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
