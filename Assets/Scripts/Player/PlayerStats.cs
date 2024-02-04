using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private int currentHealth;

    public PlayerInventory inventory;

    [SerializeField]
    private TMP_Text topLeftHealthText;
    [SerializeField]
    private Slider topLeftHealthSlider;

    [SerializeField]
    private GameEvent loseLevelEvent;

    private SpriteRenderer sr;

    #region Stats
    #region BaseStats
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int baseHealth = 1000;
    [SerializeField]
    private int baseAttack = 1;
    #endregion
    #region Modifiers
    public int vitality = 0;
    public int attackPower = 0;
    public IntEvent attackPowerChangedEvent;
    public IntEvent vitalityPowerChangedEvent;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        maxHealth += (vitality * 2);
        baseHealth += (vitality * 2);
        attackPowerChangedEvent.Raise(attackPower);
        vitalityPowerChangedEvent.Raise(vitality);
        inventory.Clear();
        currentHealth = maxHealth;
        UpdateHealthBars();
        sr = GetComponentInChildren<SpriteRenderer>();
    }   

    public void UpdateHealthBars()
    {
        healthSlider.value = GetHealthRatio();
        topLeftHealthSlider.value = GetHealthRatio();
        topLeftHealthText.text = $"{currentHealth}/{maxHealth}";
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        ShowFloatingText($"-{amount}");

        UpdateHealthBars();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        loseLevelEvent.Raise();
    }

    private float GetHealthRatio()
    {
        return ((float)currentHealth / (float)maxHealth);
    }

    public void Heal(float hpPercent)
    {
        int hpToHeal = (int)((maxHealth / 100) * hpPercent);
        int newHp = Mathf.Clamp(hpToHeal + currentHealth, 0, maxHealth);
        currentHealth = newHp;
        UpdateHealthBars();
    }

    public void EarnItem(AItem newItem)
    {

        inventory.AddItem(newItem);
    }

    public int GetAttackPower()
    {
        return attackPower;
    }

    public int GetBaseAttack()
    {
        return attackPower;
    }

    private void ShowFloatingText(string text)
    {
        TMP_Text tempText = Instantiate(damageTextPrefab, transform.position, transform.rotation).GetComponent<TMP_Text>();
        SetRandomTransformForFloatingText(tempText.transform);
        tempText.text = text;
        tempText.color = Color.red;
        FloatingText floatingText = tempText.GetComponent<FloatingText>();
        tempText.transform.DOMoveY(floatingText.speed * floatingText.DestroyTime, floatingText.DestroyTime);
        //StartCoroutine(tempText.GetComponent<FloatingText>().MoveUpward());
    }

    private void SetRandomTransformForFloatingText(Transform transformToMod,float offset = .1f)
    {
        float diameter= sr.bounds.size.x;
        float height = sr.bounds.size.y;

        float xOffset = Random.Range(-diameter, diameter);

        float randomX = transform.position.x + xOffset;
        float randomY = transform.position.y + height/2 + offset;
        Vector3 newPos = new Vector3(randomX,randomY);

        transformToMod.position = newPos;
    }

    public void ChangeVitality(int amount)
    {
        vitality += amount;
        maxHealth += (amount * 2);
        currentHealth += (amount * 2);
        vitalityPowerChangedEvent.Raise(vitality);
        UpdateHealthBars();
    }

    public void ChangeAttackPower(int amount)
    {
        attackPower += amount;
        baseAttack += amount * 2;
        attackPowerChangedEvent.Raise(attackPower);
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
