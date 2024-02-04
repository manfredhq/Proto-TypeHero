using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int attack;
    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private GOEvent deathEvent;

    [SerializeField]
    private IntEvent attackEvent;

    private SpriteRenderer sr;

    private Animator animator;

    [Header("Audio")]
    [SerializeField]
    private AudioClipFloatEvent audioEvent;
    [SerializeField]
    private AudioClipInfo attackSound;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = GetHealthRatio();
        //StartCoroutine(Attack());
        sr = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        animator.Play("Attack");
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        ShowFloatingText($"-{amount}");
        healthBar.value = GetHealthRatio();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        deathEvent.Raise(gameObject);
    }

    public void ProccesDamage(int goodLetters, int badLetters)
    {
        TakeDamage(goodLetters);
    }

    public float GetHealthRatio()
    {
        return ((float)currentHealth / (float)maxHealth);
    }

    private IEnumerator Attack()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(attackSpeed);
            attackEvent.Raise(attack);
        }
        yield return null;
    }

    public void DealDamage()
    {
        attackEvent.Raise(attack);
    }

    private void ShowFloatingText(string text)
    {
        TMP_Text tempText = Instantiate(damageTextPrefab, transform.position, transform.rotation).GetComponent<TMP_Text>();
        SetRandomTransformForFloatingText(tempText.transform);
        tempText.text = text;
        tempText.color = Color.red;
        FloatingText floatingText = tempText.GetComponent<FloatingText>();
        tempText.transform.DOMoveY(floatingText.speed * floatingText.DestroyTime, floatingText.DestroyTime);
    }

    private void SetRandomTransformForFloatingText(Transform transformToMod, float offset = .1f)
    {
        float diameter = sr.bounds.size.x;
        float height = sr.bounds.size.y;

        float xOffset = Random.Range(-diameter, diameter);

        float randomX = transform.position.x + xOffset;
        float randomY = transform.position.y + height / 2 + offset;
        Vector3 newPos = new Vector3(randomX, randomY);

        transformToMod.position = newPos;
    }

    public void PlayAttackSound()
    {
        audioEvent.Raise(attackSound.clip, attackSound.targetVolume);
    }

    
    //DEBUG PURPOSE
    private void OnDrawGizmos()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        float diameter = sr.bounds.size.x;
        float height = sr.bounds.size.y;

        Gizmos.DrawLine(new Vector3(transform.position.x + diameter / 2, transform.position.y + height / 2 + .1f), new Vector3(transform.position.x - diameter / 2, transform.position.y + height / 2 + .1f));
    }
}
