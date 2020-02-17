using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Vertex
{
    [SerializeField] Vector2 _index;
    [SerializeField] List<Vertex> _neightbours = new List<Vertex>();
    float _heuristicValue = 0;
    int _pathValue = 1;
    int _currentPathLength = 0;
    bool _isOccupied = false;
    VertType _vertType;
    Color _freeColor;
    Color _occupiedColor;
    Vertex _partent;

    Vector3 _worldPosition;
    SpriteRenderer _buildingVertex;
    public Vector2 Index { get => _index; set => _index = value; }
    public float HeuristicValue { get => _heuristicValue; set => _heuristicValue = value; }
    public int PathValue { get => _pathValue; set => _pathValue = value; }
    public bool IsOccupied
    {
        get => _isOccupied;
        set
        {
            _isOccupied = value;
            _buildingVertex.color = GetVertexColor();
        }
    }
    public List<Vertex> Neightbours { get => _neightbours; }
    public Vector3 WorldPosition { get => _worldPosition; set => _worldPosition = value; }
    public VertType VertType { get => _vertType; }

    public float FullCost
    {
        get => _heuristicValue + _pathValue;
    }
    public int CurrentPathLength { get => _currentPathLength; set => _currentPathLength = value; }
    public Vertex Partent { get => _partent; set => _partent = value; }

    public Vertex(Vector2 index, VertType vertType, Vector3 worldPosition, bool isOccupied, GameObject vertexPrefab, Color freeColor, Color occupiedColor, Transform mapHolder)
    {
        _index = index;
        _vertType = vertType;
        _worldPosition = worldPosition;
        _isOccupied = isOccupied;
        _buildingVertex = GameObject.Instantiate(vertexPrefab, worldPosition, Quaternion.identity, mapHolder).GetComponent<SpriteRenderer>();
        _freeColor = freeColor;
        _occupiedColor = occupiedColor;
        _buildingVertex.color = GetVertexColor();
    }

    private Color GetVertexColor()
    {
        return !_isOccupied ? _freeColor : _occupiedColor;
    }

    public void AddConnection(Vertex vertex)
    {
        _neightbours.Add(vertex);
    }
}

