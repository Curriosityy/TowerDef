using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
public class GridCreator : MonoBehaviour
{
    [SerializeField] private Grid _gameGrid;
    private Vertex[,] _grid2;
    private Dictionary<Vector3, Vertex> _grid;
    [SerializeField] private int _heigthSize = 10, _widthSize = 10;
    private Vector2 _worldGridSize;
    [SerializeField] bool _showGrid = false;
    [SerializeField] GameObject _buildingVertexPrefab;
    [SerializeField] Color _freeVertex, _ocupiedVertex;
    [SerializeField] Transform _mapHolder;
    public Dictionary<Vector3, Vertex> Grid { get => _grid; set => _grid = value; }
    private void Awake()
    {
        _worldGridSize = new Vector2(_widthSize / 2, _heigthSize / 2);
        _grid2 = new Vertex[_widthSize, _heigthSize];
        _grid = new Dictionary<Vector3, Vertex>();
        CreateMap();
        MakeConnections();
    }

    public Vertex WorldPositionToNode(Vector3 objectWorldPosition)
    {
        var cellPos = _gameGrid.GetCellCenterWorld(_gameGrid.WorldToCell(objectWorldPosition));
        Vertex vertex;
        _grid.TryGetValue(cellPos, out vertex);
        return vertex;
    }

    private void MakeConnections()
    {
        Vertex vert = null;
        Vertex connectTo = null;

        for (int j = 0; j < _heigthSize; j++)
        {
            for (int i = 0; i < _widthSize; i++)
            {
                vert = _grid2[i, j];
                if (j + 1 < _heigthSize)
                {
                    connectTo = _grid2[i, j + 1];
                    vert.AddConnection(connectTo);
                    connectTo.AddConnection(vert);
                }
                if (i + 1 < _widthSize)
                {
                    connectTo = _grid2[i + 1, j];
                    vert.AddConnection(connectTo);
                    connectTo.AddConnection(vert);
                }
                if (j % 2 == 1 && i - 1 >= 0 && j + 1 < _heigthSize)
                {
                    connectTo = _grid2[i - 1, j + 1];
                    vert.AddConnection(connectTo);
                    connectTo.AddConnection(vert);
                }
                if ((j % 2 == 0 && i + 1 < _widthSize && j + 1 < _heigthSize))
                {
                    connectTo = _grid2[i + 1, j + 1];
                    vert.AddConnection(connectTo);
                    connectTo.AddConnection(vert);
                }

            }
        }
    }

    private void CreateMap()
    {
        Vertex vert = null;
        bool isOccupied = false;
        for (int j = 0; j < _heigthSize; j++)
        {
            for (int i = 0; i < _widthSize; i++)
            {
                isOccupied = false;
                Vector3 pos = _gameGrid.GetCellCenterWorld(new Vector3Int((int)-_worldGridSize.x + i, (int)_worldGridSize.y - j, 0));
                var colliders = Physics2D.OverlapCircleAll(pos, 0.2f);
                foreach (var collider in colliders)
                {
                    if (!collider.isTrigger)
                    {
                        isOccupied = true;
                        break;
                    }
                }
                vert = new Vertex(new Vector2(i, j), VertType.middle, pos, isOccupied,_buildingVertexPrefab,_freeVertex,_ocupiedVertex,_mapHolder);

                _grid.Add(pos, vert);
                _grid2[i, j] = vert;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (_showGrid)
        {
            if (_grid2 != null)
            {
                foreach (var vert in _grid2)
                {
                    if (vert.IsOccupied)
                    {
                        Gizmos.color = Color.black;
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                    }
                    Gizmos.DrawSphere(vert.WorldPosition, 0.2f);
                }
            }
        }

    }
}
