namespace UndirectedGraph;

class Graph
{
    private Dictionary<int, List<int>> adjacency;

    public Graph()
    {
        adjacency = new Dictionary<int, List<int>>();
    }

    public void AddVertex(int vertex)
    {
        if (!adjacency.ContainsKey(vertex))
        {
            adjacency[vertex] = new List<int>();
        }
    }

    public void AddEdge(int vertex1, int vertex2)
    {
        if (!adjacency.ContainsKey(vertex1) || !adjacency.ContainsKey(vertex2))
        {
            throw new ArgumentException("Мне зачем такое надо");
        }

        if (!adjacency[vertex1].Contains(vertex2))
        {
            adjacency[vertex1].Add(vertex2);
        }

        if (!adjacency[vertex2].Contains(vertex1))
        {
            adjacency[vertex2].Add(vertex1);
        }
    }

    public void RemoveVertex(int vertex)
    {
        if (!adjacency.ContainsKey(vertex))
        {
            throw new ArgumentException("И чё удалять");
        }

        adjacency.Remove(vertex);

        foreach (var adjList in adjacency.Values)
        {
            adjList.Remove(vertex);
        }
    }

    public void RemoveEdge(int vertex1, int vertex2)
    {
        if (!adjacency.ContainsKey(vertex1) || !adjacency.ContainsKey(vertex2))
        {
            throw new ArgumentException("Извините, что");
        }

        adjacency[vertex1].Remove(vertex2);
        adjacency[vertex2].Remove(vertex1);
    }

    public void PrintGraph()
    {
        foreach (var kvp in adjacency)
        {
            int vertex = kvp.Key;
            List<int> adjacentVertices = kvp.Value;
            string adjacentVerticesStr = string.Join(", ", adjacentVertices);
            Console.WriteLine($"{vertex,6} | {adjacentVerticesStr}");
        }
    }
}