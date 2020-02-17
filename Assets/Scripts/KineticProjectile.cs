using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticProjectile : ProjectileBehaviour
{
    protected override void DealDamage(Monster monster)
    {
        monster.DealDamage(_dmg);
    }

    protected override void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    protected override void MoveProjectile()
    {
        var dir = ((Vector2)_target.transform.position - (Vector2)transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(dir * Speed);
    }

    
}
