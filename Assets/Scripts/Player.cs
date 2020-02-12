using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamagable
{
    [SerializeField] private int _health=15;
    [SerializeField] private int _money=0;

    public int Health { get => _health; set => _health = value; }

    public bool IsDead => throw new System.NotImplementedException();

    public int Money { get => _money; set => _money = value; }

    public void DealDamage(int damage)
    {
        _health -= damage;
        if(_health<=0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        throw new NotImplementedException();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
