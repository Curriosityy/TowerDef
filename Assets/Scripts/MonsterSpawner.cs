using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]GameObject[] _monsters;
    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player=FindObjectOfType<Player>();
        StartCoroutine("SpawnMinions");
    }

    IEnumerator SpawnMinions()
    {
        for(int i=0;i<100;i++)
        {
            var monster = Instantiate(_monsters[0], GetComponent<PathOrganizer>().StartPos.position, Quaternion.identity, null).GetComponent<Monster>();
            monster.InitializeMinion(GetComponent<PathOrganizer>().GetPath(),_player);

            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
