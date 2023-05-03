using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamageable
{
    int health { get; }
    int maxHealth { get; }
    event Action OnHealthChanged;
    event Action OnMaxHealthChanged;

}
