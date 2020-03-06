using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLinker : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _gameWonPanel;

    public GameObject GameOverPanel { get => _gameOverPanel; }
    public GameObject GameWonPanel { get => _gameWonPanel; }
}
