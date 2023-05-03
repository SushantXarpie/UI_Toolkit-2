using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 5;

    public int health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChanged?.Invoke();
        }
    }

    public int maxHealth
    {
        get => _maxHealth;
        set
        {
            _maxHealth = value;
            OnMaxHealthChanged?.Invoke();
        }
    }

    public event Action OnHealthChanged;
    public event Action OnMaxHealthChanged;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
