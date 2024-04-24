using UndirectedGraph;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);

        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        
        graph.PrintGraph();
        
        Console.WriteLine("------------");
        
        graph.AddEdge(1,2);
        graph.PrintGraph();
        
        Console.WriteLine("-----------------");
        
        graph.RemoveEdge(2, 3);
        graph.PrintGraph();
        
        Console.WriteLine("-----------------");
        
        graph.RemoveVertex(3);
        graph.PrintGraph();
        
        Console.WriteLine("-----------------");
        graph.AddEdge(2, 4);
    }
}