using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
public abstract class ProjectileBehaviour: MonoBehaviour
{
    [SerializeField] float _speed;
    protected int _dmg;
    protected Monster _target;
    bool _hited = false;
    public float Speed { get => _speed; }
    public float Dmg { get => Dmg1;}
    public float Dmg1 { get => _dmg;}

    public void Initialize(Monster target,int damage)
    {
        _target = target;
        _dmg = damage;
        MoveProjectile();
    }

    protected abstract void MoveProjectile();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var monster = collision.GetComponent<Monster>();
        if(monster!=null && !monster.IsDead && !_hited)
        {
            _hited = true;
            DealDamage(monster);
            DestroyProjectile();
        }
        if(collision.transform.parent!=null && collision.transform.parent.tag=="ProjectileCather")
        {
            DestroyProjectile();
        }
        
    }

    protected abstract void DestroyProjectile();

    protected abstract void DealDamage(Monster monster);

}
