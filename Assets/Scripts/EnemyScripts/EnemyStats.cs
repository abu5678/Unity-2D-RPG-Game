using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    private Enemy enemy;
    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<Enemy>();
    }

    public override void takeDamage(int damageTaken)
    {
        base.takeDamage(damageTaken);
    }

    public override void Die()
    {
        base.Die();
        enemy.die();
    }
}
