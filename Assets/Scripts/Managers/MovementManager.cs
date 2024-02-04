using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    private bool canMove = true;

    [SerializeField]
    private bool canMoveLeft = true;

    [SerializeField]
    private GOEvent startFight;

    [SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private GameEvent levelEndedEvent;

    [SerializeField]
    private AudioClipInfo playerMoveAudioClip;

    [SerializeField]
    private AudioClipFloatEvent audioClipEvent;

    public void OnFightEnd()
    {
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "triggerFight")
        {
            startFight.Raise(collision.gameObject);
            canMove = false;
        }
        else if (collision.tag == "triggerEndLevel")
        {
            levelEndedEvent.Raise();
            SetCanMove(false);
        }
        if(collision.tag == "movementBlock")
        {
            canMoveLeft = false;
        }
    }

    private void Update()
    {
        if (canMove && Input.GetAxisRaw("Horizontal") == 1)
        {
            parent.transform.position += Vector3.right * Time.deltaTime * movementSpeed;
            canMoveLeft = true;
            audioClipEvent.Raise(playerMoveAudioClip.clip, playerMoveAudioClip.targetVolume);
        }
        else if (canMoveLeft & canMove && Input.GetAxisRaw("Horizontal") == -1)
        {
            parent.transform.position += Vector3.left * Time.deltaTime * movementSpeed;
            audioClipEvent.Raise(playerMoveAudioClip.clip, playerMoveAudioClip.targetVolume);
        }
        
        
    }

    public void SetCanMove(bool newValue)
    {
        canMove = newValue;
    }

    public void SetCanMoveInversed(bool newValue)
    {
        canMove = !newValue;
    }
}
