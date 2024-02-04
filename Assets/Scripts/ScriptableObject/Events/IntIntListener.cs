using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntIntListener : MonoBehaviour
{
    [SerializeField]
    private IntIntEvent _event;

    [SerializeField]
    private UnityEvent<int,int> _onEventRaised;

    public void OnEventRaised(int i1, int i2)
    {
        _onEventRaised.Invoke(i1,i2);
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
