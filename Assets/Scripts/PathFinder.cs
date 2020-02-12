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
        SortedSet<Vertex> openList = new SortedSet<Vertex>(new VertexComparer());
        HashSet<Vertex> closedSet = new HashSet<Vertex>();
        openList.Add(_startVert);
        Stack<Vertex> path = new Stack<Vertex>();
        Vertex current;
        //openList.Add(0, copiedVertices[from.Index]);
        while (openList.Count > 0)
        {
            current = openList.First();
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

    private static void CalculateFullValue(float pathLength, Vertex vertexToCalculate)
    {

    }

}

