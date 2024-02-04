using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringListener : MonoBehaviour
{
    [SerializeField]
    private StringEvent _event;

    [SerializeField]
    private UnityEvent<string> _onEventRaised;

    public void OnEventRaised(string s)
    {
        _onEventRaised.Invoke(s);
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
