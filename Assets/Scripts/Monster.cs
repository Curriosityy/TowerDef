using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour,IDamagable
{
    [SerializeField] int _hp=1;
    [SerializeField] int _damage=1;
    Stack<Vertex> _path;
    [SerializeField] float _walkingSpeed=1;
    bool _isDead = false;
    [SerializeField] int _money = 1;
    public bool IsDead { get => _isDead; }
    Player _player;
    public void DealDamage(int damage)
    {
        //Spawn dmg text;
        _hp -= damage;
        if(_hp <= 0)
        {
            ///Spawn money text +1;
            _player.Money += _money;
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        StopAllCoroutines();
        Destroy(gameObject,1f);
    }

    private void DealDamageToPlayer()
    {
        //Spawn 
        _player.DealDamage(_damage);
        Die();
    }

    public void InitializeMinion(Stack<Vertex> path, Player player)
    {
        _path = path;
        _player = player;
        StartCoroutine("MoveToExit");
    }

    public IEnumerator MoveToExit()
    {
        Debug.Log("Monster start to move");
        Vertex currentTarget;
        while(_path.Count!=0)
        {
            currentTarget = _path.Pop();
            LookAt(currentTarget);
            while (transform.position != currentTarget.WorldPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    currentTarget.WorldPosition,
                    _walkingSpeed * Time.deltaTime);
                yield return null;
            }
        }
        DealDamageToPlayer();
        yield return null;
    }

    private void LookAt(Vertex currentTarget)
    {
        var diff = currentTarget.WorldPosition - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
