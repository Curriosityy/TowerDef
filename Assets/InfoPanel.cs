using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _costText;
    [SerializeField] TMP_Text _firerateText;
    [SerializeField] TMP_Text _dmgText;
    [SerializeField] TMP_Text _descText;
    Turret _turret;

    public Turret Turret { get => _turret; }

    public void Initialize(Turret turret)
    {
        _costText.text = turret.Cost.ToString();
        _firerateText.text = turret.FireRate.ToString();
        _dmgText.text = turret.Damage.ToString();
        _descText.text = "Description: " + turret.Description;
        _turret = turret;
    }
}
