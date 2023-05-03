using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : HealthUI
{
    private ProgressBar healthBar;

    protected override void OnEnable()
    {
        base.OnEnable();
        healthBar = uiDocument.rootVisualElement.Q<ProgressBar>("HealthBar");
        healthBar.value = (float)damageable.health / damageable.maxHealth;
    }

    protected override void UpdateHealth()
    {
        healthBar.value = (float)damageable.health / damageable.maxHealth;

        if (damageable.health > 0)
        {
            if (uiDocument.rootVisualElement.style.display == DisplayStyle.None)
                uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        }
        else
        {
            uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        }
    }

    protected override void UpdateMaxHealth()
    {
        healthBar.value = (float)damageable.health / damageable.maxHealth;
    }
}
