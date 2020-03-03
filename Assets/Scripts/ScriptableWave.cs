
using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Wave")]
class ScriptableWave:ScriptableObject
{
    [SerializeField]
    List<Pack> _packsInWave;
    [SerializeField]
    int _waveTime;

    public int WaveTime { get => _waveTime;}
    internal List<Pack> PacksInWave { get => _packsInWave;}
}

