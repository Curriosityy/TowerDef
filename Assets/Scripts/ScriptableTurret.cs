using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Turret", menuName = "ScriptableObjects/Turret")]
public class ScriptableTurret : ScriptableObject
{
    [SerializeField] private float _range = 2f;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private int _cost = 100;
    [SerializeField] private String _description = "Lorem ipsum";
    [SerializeField] private ScriptableTurret _upgrade;
    [SerializeField] private Sprite _turretSprite;
    [SerializeField] private ProjectileBehaviour _projectilePrefab;
    public float Range { get => _range; }
    public int Damage { get => _damage; }
    public float FireRate { get => _fireRate; }
    public int Cost { get => _cost; }
    public string Description { get => _description; }
    public ScriptableTurret Upgrade { get => _upgrade; }
    public Sprite TurretSprite { get => _turretSprite; }
    public ProjectileBehaviour Projectile { get => _projectilePrefab; }
}
