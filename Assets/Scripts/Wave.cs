using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
[Serializable]
public class Wave
{
    [SerializeField]
    List<Pack> _packs;
    [SerializeField]
    int _revardForWave;

    public int RevardForWave { get => _revardForWave;}
    public List<Pack> Packs { get => _packs;}
}
