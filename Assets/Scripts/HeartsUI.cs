using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeartsUI : HealthUI
{
    private VisualElement hearts;

    protected override void OnEnable()
    {
        base.OnEnable();
        hearts = uiDocument.rootVisualElement.Q<VisualElement>("panel");
        UpdateHealth();
        UpdateMaxHealth();
    }

    protected override void UpdateHealth()
    {
        for (int i = 0; i < hearts.childCount; i++)
        {
            if (i < damageable.health)
            {
                hearts[i][0].style.visibility = Visibility.Visible;
            }
            else
            {
                hearts[i][0].style.visibility = Visibility.Hidden;
            }
        }
    }

    protected override void UpdateMaxHealth()
    {
        for (int i = 0; i < hearts.childCount; i++)
        {
            if (i < damageable.maxHealth)
            {
                hearts[i][0].style.visibility = Visibility.Visible;
            }
            else
            {
                hearts[i][0].style.visibility = Visibility.Hidden;
            }
        }
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        if (owner != null)
        {
            if (owner.GetComponent<IDamageable>().maxHealth > 20)
            {
                Debug.LogError("Max Health must be less than or equal  20");
                owner = null;
            }
        }
    }
}
