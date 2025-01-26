namespace UnweightedGraphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            graph.AddVertex(new Vertex<int>(1));
            graph.AddVertex(new Vertex<int>(2));
            graph.AddVertex(new Vertex<int>(3));
            graph.AddVertex(new Vertex<int>(4));
            graph.AddEdge(graph.Search(1), graph.Search(2));
            graph.AddEdge(graph.Search(1), graph.Search(3));
            graph.AddEdge(graph.Search(1), graph.Search(4));
            graph.DepthFirstTraversal(graph.Search(1));
            ;
        }
    }
}
