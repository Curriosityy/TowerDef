using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class VertexComparer : IComparer<Vertex>
{
    public int Compare(Vertex x, Vertex y)
    {
        return x.FullCost.CompareTo(y.FullCost);
    }
}

