using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControler : MonoBehaviour
{
    WaveSpawner _monsterSpawner;
    [SerializeField] List<Wave> _waves = null;
    int _waveCouner = 0;

    public int WaveCouner { get => _waveCouner; }

    // Start is called before the first frame update
    void Start()
    {
        _monsterSpawner = GetComponent<WaveSpawner>();
    }

    public void SpawnNewPack()
    {
        if(IsNextWaveExist)
        {
            var wave = _waves[_waveCouner].Packs;
            StartCoroutine(_monsterSpawner.SpawnWave(wave));
            _waveCouner++;
        }
    }
    
    public bool IsNextWaveExist { get => _waveCouner < _waves.Count; }
}
