using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInfoUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text _healthText;
    [SerializeField] TMP_Text _coinsText;

    private void Update()
    {

    }
    public void UpdateHealthInfo(int hp)
    {
        _healthText.text = hp.ToString();
    }
    public void UpdateCoinInfo(int coins)
    {
        _coinsText.text = coins.ToString();
    }
}
