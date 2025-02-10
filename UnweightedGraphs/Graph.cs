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

        public void IterativeDepthFirstTraversal(Vertex<T> start, List<Vertex<T>> popped)
        {
            if(Vertices.Contains(start) == false) { return; }
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            stack.Push(start);
            visited.Add(start);
            
            while(stack.Count > 0)
            {
                Vertex<T> current = stack.Peek();
                
                popped.Add(stack.Pop());

                for (int i = current.NeighborCount - 1; i > -1; i--)
                {
                    if (!visited.Contains(current.Neighbors[i]))
                    {
                        stack.Push(current.Neighbors[i]);
                        visited.Add(current.Neighbors[i]);
                    }
                }

   

            }


        }

        public void BreadthFirstTraversal(Vertex<T> start, List<Vertex<T>> dequed)  
        {
            if(Vertices.Contains(start) == false) { return; }
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            queue.Enqueue(start);
            visited.Add(start);
            while (queue.Count > 0)
            {
                Vertex<T> current = queue.Peek();
               
                dequed.Add(queue.Dequeue());
                for(int i = 0; i < current.NeighborCount; i++)
                {
                    if (!visited.Contains(current.Neighbors[i]))
                    {
                        queue.Enqueue(current.Neighbors[i]);
                        visited.Add(current.Neighbors[i]);
                    }
                }
            }
        }

        //make breadth first and connect dictionary to path
        public List<Vertex<T>> SingleSourceShortedPath(Vertex<T> start, Vertex<T> end)
        {
            if (Vertices.Contains(start) == false) { return null; }
            Dictionary<Vertex<T>, Vertex<T>> previousVertex = new Dictionary<Vertex<T>, Vertex<T>>();
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            queue.Enqueue(start);
            visited.Add(start);
            while (queue.Count > 0)
            {
                Vertex<T> current = queue.Dequeue();

                if (current.Equals(end))
                {
                    List<Vertex<T>> path = new List<Vertex<T>>();
                    while (current != null)
                    {
                        path.Add(current);
                        if (previousVertex.ContainsKey(current))
                        {
                            current = previousVertex[current];
                        }
                        else
                        {
                            current = null;
                        }
                    }
                    path.Reverse();
                    return path;
                }

                for (int i = 0; i < current.NeighborCount; i++)
                {
                    if (!visited.Contains(current.Neighbors[i]))
                    {
                        queue.Enqueue(current.Neighbors[i]);
                        visited.Add(current.Neighbors[i]);
                        previousVertex[current.Neighbors[i]] = current;
                    }
                }
            }
            return null;

        }

    }
}
