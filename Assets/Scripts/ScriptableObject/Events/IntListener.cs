using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntListener : MonoBehaviour
{
    [SerializeField]
    private IntEvent _event;

    [SerializeField]
    private UnityEvent<int> _onEventRaised;

    public void OnEventRaised(int i1)
    {
        _onEventRaised.Invoke(i1);
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
