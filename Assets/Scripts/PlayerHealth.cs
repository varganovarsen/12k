using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    private int _health;
    public int Health => _health;

    [SerializeField]
    private int _maxHealth;

    public static event Action<int> OnHealthChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    private void Start()
    {
        ResetHealth();
    }

    public void DealDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
            Die();

        _health = Mathf.Clamp(_health, 0,int.MaxValue);

        OnHealthChanged?.Invoke(_health);
    }

    public void ResetHealth()
    {
        _health = _maxHealth;
        OnHealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        Debug.Log("You are dead");

        GetComponent<SpriteRenderer>().color = Color.gray;
        PlayerMovement.Instance.DisableInput();
        
    }
}
