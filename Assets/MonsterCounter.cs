using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCounter : MonoBehaviour,IObserver
{

    int _monsterCount;

    public int MonsterCount { get => _monsterCount; set => _monsterCount = value; }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IObserver.Update()
    {
        _monsterCount--;
    }
}
