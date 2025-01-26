namespace UnweightedGraphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Graph<int> graph = new Graph<int>();

            graph.AddVertex(new Vertex<int>(1));
            graph.AddVertex(new Vertex<int>(2));
            graph.AddEdge(graph.Vertices[0], graph.Vertices[1]);
            graph.RemoveVertex(graph.Vertices[0]);
            ;
        }
    }
}
