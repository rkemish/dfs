using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Represent the graph as an adjacency list with distances in miles
        var graph = new Dictionary<string, List<(string, int)>>()
        {
            { "New York", new List<(string, int)> { ("Boston", 215), ("Philadelphia", 94), ("Washington D.C.", 225) } },
            { "Boston", new List<(string, int)> { ("New York", 215) } },
            { "Philadelphia", new List<(string, int)> { ("New York", 94), ("Washington D.C.", 140) } },
            { "Washington D.C.", new List<(string, int)> { ("New York", 225), ("Philadelphia", 140) } },
            { "Chicago", new List<(string, int)> { ("Detroit", 281), ("Milwaukee", 92) } },
            { "Detroit", new List<(string, int)> { ("Chicago", 281) } },
            { "Milwaukee", new List<(string, int)> { ("Chicago", 92) } },
            { "Los Angeles", new List<(string, int)> { ("San Francisco", 382), ("Las Vegas", 270) } },
            { "San Francisco", new List<(string, int)> { ("Los Angeles", 382) } },
            { "Las Vegas", new List<(string, int)> { ("Los Angeles", 270) } }
        };

        // Step 2: Input start and end cities
        string startCity = "New York";
        string endCity = "Washington D.C.";

        // Step 3: Find the best path using DFS
        var bestPath = FindBestPath(graph, startCity, endCity);

        // Step 4: Print the result
        if (bestPath != null)
        {
            Console.WriteLine("Best Path:");
            Console.WriteLine(string.Join(" -> ", bestPath.Path));
            Console.WriteLine($"Total Distance: {bestPath.Distance} miles");
        }
        else
        {
            Console.WriteLine("No path found between the two cities.");
        }
    }

    // Helper class to store the best path and its distance
    class PathInfo
    {
        public List<string> Path { get; set; }
        public int Distance { get; set; }
    }

    static PathInfo FindBestPath(Dictionary<string, List<(string, int)>> graph, string start, string end)
    {
        var visited = new HashSet<string>();
        var bestPath = new PathInfo { Path = new List<string>(), Distance = int.MaxValue };

        DFS(graph, start, end, visited, new List<string>(), 0, bestPath);

        return bestPath.Distance == int.MaxValue ? null : bestPath; // Return null if no path is found
    }

    static void DFS(
        Dictionary<string, List<(string, int)>> graph,
        string current,
        string end,
        HashSet<string> visited,
        List<string> currentPath,
        int currentDistance,
        PathInfo bestPath)
    {
        // Step 1: Mark the current city as visited and add it to the path
        visited.Add(current);
        currentPath.Add(current);

        // Step 2: Check if we've reached the destination
        if (current == end)
        {
            if (currentDistance < bestPath.Distance)
            {
                bestPath.Path = new List<string>(currentPath);
                bestPath.Distance = currentDistance;
            }
        }
        else
        {
            // Step 3: Recur for all unvisited neighbors
            foreach (var (neighbor, distance) in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    DFS(graph, neighbor, end, visited, currentPath, currentDistance + distance, bestPath);
                }
            }
        }

        // Step 4: Backtrack
        visited.Remove(current);
        currentPath.RemoveAt(currentPath.Count - 1);
    }
}