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

        // Step 3: Find the best path using iterative DFS
        var bestPath = FindBestPathIterative(graph, startCity, endCity);

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

    static PathInfo FindBestPathIterative(Dictionary<string, List<(string, int)>> graph, string start, string end)
    {
        var visited = new HashSet<string>();
        var stack = new Stack<(string currentCity, List<string> path, int distance)>();

        stack.Push((start, new List<string> { start }, 0));
        PathInfo bestPath = new PathInfo { Path = new List<string>(), Distance = int.MaxValue };

        while (stack.Count > 0)
        {
            // Step 1: Pop the top node
            var (currentCity, currentPath, currentDistance) = stack.Pop();

            // Step 2: If we've already visited the city, skip it
            if (visited.Contains(currentCity) && currentCity != end) continue;

            // Step 3: Mark the city as visited (for the current path)
            visited.Add(currentCity);

            // Step 4: Check if we've reached the destination
            if (currentCity == end)
            {
                if (currentDistance < bestPath.Distance)
                {
                    bestPath.Path = new List<string>(currentPath);
                    bestPath.Distance = currentDistance;
                }
            }
            else
            {
                // Step 5: Push all neighbors onto the stack
                foreach (var (neighbor, distance) in graph[currentCity])
                {
                    if (!currentPath.Contains(neighbor)) // Avoid cycles in the path
                    {
                        var newPath = new List<string>(currentPath) { neighbor };
                        stack.Push((neighbor, newPath, currentDistance + distance));
                    }
                }
            }

            // Step 6: Backtrack by removing the city from visited if necessary
            visited.Remove(currentCity);
        }

        return bestPath.Distance == int.MaxValue ? null : bestPath;
    }
}