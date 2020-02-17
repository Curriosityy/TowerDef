using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShop : MonoBehaviour
{
    [SerializeField] Turret[] _turrets;
    [SerializeField] GameObject _turretView;

    // Start is called before the first frame update
    void Start()
    {
        AddItemsToShop();
    }

    private void AddItemsToShop()
    {
        GameObject gameObject;

        for (int i = 0; i < _turrets.Length; i++)
        {
            gameObject = Instantiate(_turretView, transform);
            var pos = gameObject.GetComponent<RectTransform>().localPosition;
            pos.x += i * gameObject.GetComponent<RectTransform>().sizeDelta.x;
            gameObject.GetComponent<RectTransform>().localPosition = pos;
            gameObject.GetComponent<InfoPanel>().Initialize(_turrets[i]);

        }
    }

}
