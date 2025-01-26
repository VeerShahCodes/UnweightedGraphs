using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnweightedGraphs
{
    public class Graph<T>
        where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public int VertexCount => Vertices.Count;

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public bool AddVertex(Vertex<T> vertex)
        {
            if(vertex != null && vertex.NeighborCount == 0 && !Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
                return true;
            }
            return false;
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if(Vertices.Contains(vertex))
            {
                for(int i = 0; i < vertex.NeighborCount; i++)
                {
                    RemoveEdge(vertex, vertex.Neighbors[i]);
                }
                Vertices.Remove(vertex);
                return true;
            }
            return false;
        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if((a == null || b == null) || (!Vertices.Contains(a) || !Vertices.Contains(b))) return false;
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
            return true;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if((a != null && b != null) && (Vertices.Contains(a) && Vertices.Contains(b)) && (a.Neighbors.Contains(b) && b.Neighbors.Contains(a)))
            {
                a.Neighbors.Remove(b);
                b.Neighbors.Remove(a);
                return true;
            }

            return false;
        }

        public Vertex<T> Search(T value)
        {
            for(int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].value.CompareTo(value) == 0) return Vertices[i];
            }
            return null;
        }

        public void DepthFirstTraversal(Vertex<T> start)
        {
            if (Vertices.Contains(start) == false) return;
            else
            {
                HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
                
                RecDepthFirst(start, visited);
            }
        }
        public void RecDepthFirst(Vertex<T> current, HashSet<Vertex<T>> visited)
        {
            visited.Add(current);
            Console.WriteLine(current.value);
            for(int i = 0; i < current.Neighbors.Count; i++)
            {
                if (!visited.Contains(current.Neighbors[i]))
                {
                    RecDepthFirst(current.Neighbors[i], visited);
                }
     
            }
        }

        public void IterativeDepthFirstTraversal(Vertex<T> start)
        {
            //todo
 

        }

    }
}
