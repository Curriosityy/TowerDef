using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public abstract class Turret : MonoBehaviour
{

    [SerializeField] ScriptableTurret _turetInfo;
    [SerializeField] SpriteRenderer _spriteHolder;
    
    float _fireTimer = 1f;
    List<Monster> _targets;
    Monster _target;
    public int Damage { get => _turetInfo.Damage;}
    public float FireRate { get => _turetInfo.FireRate;}
    public float Range { get => _turetInfo.Range;}
    public string Description { get => _turetInfo.Description; }
    public int Cost { get =>_turetInfo.Cost; }
    public ScriptableTurret Upgrade { get => _turetInfo.Upgrade; }
    public Sprite Sprite { get => _turetInfo.TurretSprite; }
    public Monster Target { get => _target;}
    public ProjectileBehaviour ProjectilePrefav { get => _turetInfo.Projectile; }
    // Start is called before the first frame update

    void Start()
    {
        _targets = new List<Monster>();
        SetSprite();
        GetComponent<CircleCollider2D>().radius = Range;
    }

    private void SetSprite()
    {
        _spriteHolder.sprite = Sprite;
    }

    public bool CanBeUpgrade()
    {
        return Upgrade == null ? false : true;
    }

    public void UpgradeTurret()
    {
        _turetInfo = _turetInfo.Upgrade;
        SetSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var minion = collision.GetComponent<Monster>();
        if (minion != null)
        {
            _targets.Add(minion);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var minion = collision.GetComponent<Monster>();
        if (minion != null)
        {
            if (minion == _target)
            {
                _target = null;
            }
            _targets.Remove(minion);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _fireTimer += Time.deltaTime;
        if (_target == null || _target.IsDead)
        {
            SetTarget();
        }
        else
        {
            LookAtTarget();
            if (_fireTimer >= FireRate)
            {
                Fire();
                _fireTimer = 0f;
            }
        }
    }

    protected abstract void Fire();

    private void LookAtTarget()
    {
        var diff = _target.transform.position - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void SetTarget()
    {
        RefreshTargetList();
        if (_targets.Count > 0)
        {
            _target = _targets[0];
        }
    }

    private void RefreshTargetList()
    {
        _targets = _targets.Where(t => t != null && !t.IsDead).ToList();
    }
}
