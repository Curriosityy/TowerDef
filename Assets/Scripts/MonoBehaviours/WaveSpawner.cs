using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WaveSpawner : MonoBehaviour
{
    Player _player;
    [SerializeField] PathOrganizer _pathOrganizer;
    Stack<Vertex> _path;
    Animator _animator;
    public Stack<Vertex> Path { get => _path; set => _path = value; }
    public PathOrganizer PathOrganizer { get => _pathOrganizer; set => _pathOrganizer = value; }
    public bool IsSpawning { get => _isSpawning; }
    MonsterCounter _monsterCounter;
    private bool _isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        _player=FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _monsterCounter = GetComponent<MonsterCounter>();
    }

    public IEnumerator SpawnWave(List<Pack> wave)
    {
        foreach(var pack in wave)
        {
            for (int i = 0; i < pack.MonsterPackSize; i++)
            {
                var monster = Instantiate(pack.MonsterWave, PathOrganizer.StartPos.position, Quaternion.identity, null).GetComponent<Monster>();
                monster.InitializeMinion(new Stack<Vertex>(_path.Reverse()), _player,_monsterCounter);
                _monsterCounter.MonsterCount++;
                yield return new WaitForSeconds(pack.TimeBetweenMonsterSpawn);
            }
        }
        while(_monsterCounter.MonsterCount>0)
        {
            yield return null;
        }
        _animator.SetTrigger("PhaseEnd");
    }
}
