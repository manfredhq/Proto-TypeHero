using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 3f;

    [SerializeField]
    private float maxMovementSpeed = 1f;

    [SerializeField]
    private float minMovementSpeed = .3f;

    [SerializeField]
    private float timeHasBeenInstantiated;

    public float speed;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        timeHasBeenInstantiated = Time.time;
        Destroy(gameObject, DestroyTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minMovementSpeed, maxMovementSpeed);
    }


}
