using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Pack
{
    [SerializeField]
    Monster _monsterWave;
    [SerializeField]
    int _monsterPackSize;
    [SerializeField]
    float _timeBetweenMonsterSpawn;

    public Monster MonsterWave { get => _monsterWave; }
    public int MonsterPackSize { get => _monsterPackSize; }
    public float TimeBetweenMonsterSpawn { get => _timeBetweenMonsterSpawn; }
}
