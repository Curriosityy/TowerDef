using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;

[RequireComponent(typeof(Player))]
public class TurretBuyer : MonoBehaviour
{
    GraphicRaycaster _graphicRaycaster;
    [SerializeField] GameObject _buildingMap;
    [SerializeField] Image _turretImage;
    PathOrganizer _pathOrganizer;
    bool _buildingMode = false;
    GridCreator _gridCreator;
    Player _player;
    Turret _turret;
    [SerializeField] Animator _battleControler;

    public bool BuildingMode { get => _buildingMode;}
    public Turret Turret { get => _turret; }

    // Start is called before the first frame update
    void Start()
    {
        _graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
        _gridCreator = FindObjectOfType<GridCreator>();
        _player = GetComponent<Player>();
        _pathOrganizer = FindObjectOfType<PathOrganizer>();
    }

    public void EnableBuilding(Turret result)
    {
        if (_player.Money >= result.Cost)
        {
            _buildingMap.SetActive(true);
            _buildingMode = true;
            _turretImage.enabled = true;
            _turret = result;
            _turretImage.sprite = _turret.Sprite;
        }
    }

    public void DisableBuilding()
    {
        _buildingMode = false;
        if (_buildingMap != null)
            _buildingMap.SetActive(false);
        if(_turretImage!=null)
        _turretImage.enabled = false;
    }

    public void BuildTurret(Vertex node)
    {
        if (node.IsOccupied || node.VertType != VertType.middle)
        {
            return;
        }
        node.IsOccupied = true;
        if (_battleControler.GetCurrentAnimatorStateInfo(0).IsName("BuildingState"))
        {
            if (!_pathOrganizer.SetNewPath())
            {
                node.IsOccupied = false;
                return;
            }
        }
        _player.Money -= _turret.Cost;
        var turret = Instantiate(_turret.gameObject);
        turret.transform.position = node.WorldPosition;
    }

    public void SetImagePos()
    {
        Vertex node = GetNodeOnMousePosition();
        Vector3 pos = Vector3.zero;
        if (node != null)
        {
            pos = Camera.main.WorldToScreenPoint(node.WorldPosition);
        }
        else
        {
            pos = Input.mousePosition;
        }
        _turretImage.transform.position = pos;
    }

    public Vertex GetNodeOnMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vertex node = _gridCreator.WorldPositionToNode(mousePos);
        return node;
    }

}

