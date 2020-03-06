using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Player),typeof(TurretBuyer))]
public class InGamecontroller : MonoBehaviour
{
    TurretBuyer _turretBuyer;
    GraphicRaycaster _graphicRaycaster;
    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _turretBuyer = GetComponent<TurretBuyer>();
        _graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_turretBuyer.BuildingMode)
        {
            _turretBuyer.SetImagePos();
            if (Input.GetMouseButtonDown(0))
            {
                Vertex node = _turretBuyer.GetNodeOnMousePosition();
                if (node != null)
                {
                    if (_player.Money >= _turretBuyer.Turret.Cost && !node.IsOccupied)
                    {
                        _turretBuyer.BuildTurret(node);
                        _turretBuyer.DisableBuilding();
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Set up the new Pointer Event
            var pointerData = new PointerEventData(EventSystem.current);
            var results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = Input.mousePosition;
            _graphicRaycaster.Raycast(pointerData, results);
            results = results.Where(e => e.gameObject.GetComponent<InfoPanel>() != null).ToList();
            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            if (results.Count > 0)
            {
                _turretBuyer.EnableBuilding(results[0].gameObject.GetComponent<InfoPanel>().Turret);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            _turretBuyer.DisableBuilding();
        }
    }

    private void OnDisable()
    {
        _turretBuyer.DisableBuilding();
    }
}
