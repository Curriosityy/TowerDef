using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugConn : MonoBehaviour
{
    List<Vertex> _vertices;
    public bool debug = false;
    // Start is called before the first frame update
    private void Awake()
    {
        _vertices = new List<Vertex>();
    }
    void Start()
    {
        
    }
    public void AddVert(Vertex v)
    {
        _vertices.Add(v);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(debug)
        foreach(var vert in _vertices)
        {
            Gizmos.DrawLine(transform.position, vert.WorldPosition);
        }
    }

}
