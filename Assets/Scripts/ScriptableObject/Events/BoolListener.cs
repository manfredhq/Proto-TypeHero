using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoolListener : MonoBehaviour
{
    [SerializeField]
    private BoolEvent _event;

    [SerializeField]
    private UnityEvent<bool> _onEventRaised;

    public void OnEventRaised(bool b)
    {
        _onEventRaised.Invoke(b);
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
