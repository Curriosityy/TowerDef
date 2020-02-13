using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
public abstract class ProjectileBehaviour: MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _dmg;
    Monster _target;

    public float Speed { get => _speed;}
    public float Dmg { get => _dmg;}

    public void Initialize(Monster target)
    {
        _target = target;
        MoveProjectile();
    }

    protected abstract void MoveProjectile();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var monster = collision.GetComponent<Monster>();
        if(monster!=null)
        {
            DealDamage();
        }
        DestroyProjectile();
    }

    protected abstract void DestroyProjectile();

    protected abstract void DealDamage();

}
