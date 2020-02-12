using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PathOrganizer : MonoBehaviour
{
    PathFinder _pathFinder;
    Stack<Vertex> _path;
    [SerializeField]Transform _startPos, _endPost;
    [SerializeField] LineRenderer _lr;
    public Transform StartPos { get => _startPos; set => _startPos = value; }
    public Transform EndPost { get => _endPost; set => _endPost = value; }
    // Start is called before the first frame update
    private void Awake()
    {
        _pathFinder = new PathFinder(_startPos.position, _endPost.position);
    }
    void Start()
    {
        
        _path = _pathFinder.FindBestPath();
        Vector3[] positions = _path.Select(e => e.WorldPosition).ToArray();
        _lr.positionCount = positions.Length;
        _lr.SetPositions(positions);
        
    }
    public Stack<Vertex> GetPath()
    {
        return _pathFinder.FindBestPath();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
