using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GOListener : MonoBehaviour
{
    [SerializeField]
    private GOEvent _event;

    [SerializeField]
    private UnityEvent<GameObject> _onEventRaised;

    public void OnEventRaised(GameObject go)
    {
        _onEventRaised.Invoke(go);
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
