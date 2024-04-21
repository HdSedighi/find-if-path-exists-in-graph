using System;
using System.Collections.Generic;

public class GraphPathFinder
{
    // Function to determine if there is a valid path from source to destination
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        // Create an adjacency list to represent the graph
        var adjacencyList = new Dictionary<int, List<int>>();

        // Initialize the adjacency list with empty lists
        for (int i = 0; i < n; i++)
        {
            adjacencyList[i] = new List<int>();
        }

        // Populate the adjacency list with the given edges
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u); // Since the graph is bi-directional
        }

        // Use a queue for breadth-first search (BFS)
        var queue = new Queue<int>();
        // Use a set to keep track of visited vertices
        var visited = new HashSet<int>();

        // Start the BFS from the source vertex
        queue.Enqueue(source);
        visited.Add(source);

        while (queue.Count > 0)
        {
            int currentVertex = queue.Dequeue();

            // If we reach the destination vertex, return true
            if (currentVertex == destination)
            {
                return true;
            }

            // Explore neighbors of the current vertex
            foreach (var neighbor in adjacencyList[currentVertex])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        // If we exhaust the search without reaching the destination, return false
        return false;
    }
}

// Example usage
class Program
{
    static void Main()
    {
        int n = 3;
        int[][] edges = new int[][]
        {
            new int[] {0, 1},
            new int[] {1, 2},
            new int[] {2, 0}
        };
        int source = 0;
        int destination = 2;

        GraphPathFinder finder = new GraphPathFinder();
        bool result = finder.ValidPath(n, edges, source, destination);
        Console.WriteLine($"Is there a valid path from {source} to {destination}? {result}");
    }
}