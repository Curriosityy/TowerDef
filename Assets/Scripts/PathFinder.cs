using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PathFinder
{
    private static bool _isInitialized = false;
    private static GridCreator _mapCreator;
    Vertex _startVert;
    Vertex _endVertex;
    public PathFinder(Vector3 startPos, Vector3 endPos)
    {
        _mapCreator = GameObject.FindObjectOfType<GridCreator>();
        _startVert = _mapCreator.WorldPositionToNode(startPos);
        _endVertex = _mapCreator.WorldPositionToNode(endPos);
    }

    private float CalculateHeuristicCost(Vertex vertex)
    {
        return Vector3.SqrMagnitude(_endVertex.WorldPosition - vertex.WorldPosition);
    }

    public Stack<Vertex> FindBestPath()
    {
        List<Vertex> openList = new List<Vertex>();
        HashSet<Vertex> closedSet = new HashSet<Vertex>();
        openList.Add(_startVert);
        Stack<Vertex> path = new Stack<Vertex>();
        Vertex current;
        //openList.Add(0, copiedVertices[from.Index]);
        while (openList.Count > 0)
        {
            current = openList[0];
            foreach(var vertex in openList)
            {
                if (vertex.FullCost < current.FullCost || (vertex.FullCost==current.FullCost && vertex.HeuristicValue<current.HeuristicValue ))
                {
                    current = vertex;
                }
            }
            openList.Remove(current);
            closedSet.Add(current);

            if(current==_endVertex)
            {
                return RetracePath();
            }

            foreach (var neighbor in current.Neightbours)
            {
                if (neighbor.IsOccupied || closedSet.Contains(neighbor))
                    continue;
                if (!openList.Contains(neighbor) || IsCurrentPathWorse(current, neighbor))
                {
                    neighbor.CurrentPathLength = current.CurrentPathLength + neighbor.PathValue;
                    neighbor.HeuristicValue = CalculateHeuristicCost(neighbor);
                    neighbor.Partent = current;

                    if(!openList.Contains(neighbor))
                        openList.Add(neighbor);
                }
            }
        }

        return null;
    }


    private Stack<Vertex> RetracePath()
    {
        Stack<Vertex> path = new Stack<Vertex>();
        path.Push(_endVertex);
        while(path.Peek()!=_startVert)
        {
            path.Push(path.Peek().Partent);
        }
        return path;
    }

    private static bool IsCurrentPathWorse(Vertex current, Vertex neighbor)
    {
        return neighbor.CurrentPathLength > current.CurrentPathLength + neighbor.PathValue;
    }

    public static void DrawCube(Vector3 pos, Color col, Vector3 scale)
    {
        Vector3 halfScale = scale * 0.5f;

        Vector3[] points = new Vector3[]
        {
            pos + new Vector3(halfScale.x,      halfScale.y,    halfScale.z),
            pos + new Vector3(-halfScale.x,     halfScale.y,    halfScale.z),
            pos + new Vector3(-halfScale.x,     -halfScale.y,   halfScale.z),
            pos + new Vector3(halfScale.x,      -halfScale.y,   halfScale.z),
            pos + new Vector3(halfScale.x,      halfScale.y,    -halfScale.z),
            pos + new Vector3(-halfScale.x,     halfScale.y,    -halfScale.z),
            pos + new Vector3(-halfScale.x,     -halfScale.y,   -halfScale.z),
            pos + new Vector3(halfScale.x,      -halfScale.y,   -halfScale.z),
        };

        Debug.DrawLine(points[0], points[1], col);
        Debug.DrawLine(points[1], points[2], col);
        Debug.DrawLine(points[2], points[3], col);
        Debug.DrawLine(points[3], points[0], col);
    }
}

