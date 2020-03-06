using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamagable
{
    [SerializeField] private int _health=15;
    [SerializeField] private int _money=0;
    private PlayerInfoUpdater _infoUpdater;

    public int Health { get => _health;
        set
        {
            _health = value;
            _infoUpdater.UpdateHealthInfo(_health);
        }
    }

    public bool IsDead => throw new System.NotImplementedException();

    public int Money { get => _money;
        set
        {
            _money = value;
            _infoUpdater.UpdateCoinInfo(_money);
        }
    }

    public void DealDamage(int damage)
    {
        Health -= damage;
        if(_health<=0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        FindObjectOfType<WaveControler>().GetComponent<Animator>().SetTrigger("GameOver");
    }

    
    // Start is called before the first frame update
    void Start()
    {
        _infoUpdater.UpdateHealthInfo(_health);
        _infoUpdater.UpdateCoinInfo(_money);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        _infoUpdater = FindObjectOfType<PlayerInfoUpdater>();
    }
}
