using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Damage
{
    public float damage;
    public IDamageable shooter;

    public Damage(IDamageable shooter, float damage)
    {
        this.damage = damage;
        this.shooter = shooter;
    }
}
