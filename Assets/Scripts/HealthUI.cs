using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public abstract class HealthUI : MonoBehaviour
{
    protected UIDocument uiDocument;
    [SerializeField] protected GameObject owner;
    protected IDamageable damageable;

    protected void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        damageable = owner.GetComponent<IDamageable>();
    }

    protected virtual void OnEnable()
    {
        damageable.OnHealthChanged += UpdateHealth;
        damageable.OnMaxHealthChanged += UpdateMaxHealth;
    }

    protected abstract void UpdateHealth();
    protected abstract void UpdateMaxHealth();

    protected virtual void OnDisable()
    {
        damageable.OnHealthChanged -= UpdateHealth;
        damageable.OnMaxHealthChanged -= UpdateMaxHealth;
    }

    protected virtual void OnValidate()
    {
        if (owner != null)
        {
            if (owner.GetComponent<IDamageable>() == null)
            {
                Debug.LogError("Owner must have Idamageble component");
                owner = null;
            }
        }
    }
}
