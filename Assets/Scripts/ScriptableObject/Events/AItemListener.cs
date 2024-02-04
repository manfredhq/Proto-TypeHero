using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AItemListener : MonoBehaviour
{
    [SerializeField]
    private AItemEvent _event;

    [SerializeField]
    private UnityEvent<AItem> _onEventRaised;

    public void OnEventRaised(AItem item)
    {
        _onEventRaised.Invoke(item);
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
