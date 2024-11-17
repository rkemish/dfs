
## Code explanation:

The C# console application uses a graph to represent the distances between cities in the US in miles.
##### Graph
``` 
var graph = new Dictionary<string, List<(string, int)>>()
{
    { "New York", new List<(string, int)> { ("Boston", 215), ("Philadelphia", 94), ("Washington D.C.", 225) } },
    { "Boston", new List<(string, int)> { ("New York", 215) } },
    { "Philadelphia", new List<(string, int)> { ("New York", 94), ("Washington D.C.", 140) } },
    ...
```

* The code uses a Dictionary to represent a graph of cities
* Each city (key) maps to a list of tuples containing connected cities and distances
* For example, New York is connected to Boston (215 miles), Philadelphia (94 miles), and Washington D.C. (225 miles)


##### PathInfo class
```dotnet
class PathInfo
{
    public List<string> Path { get; set; }
    public int Distance { get; set; }
}
```

**PathInfo** is a class to store:

* The complete path (list of cities).
* Total distance of the path.


##### Main Algorithm - FindBestPath
```dotnet
static PathInfo FindBestPath(Dictionary<string, List<(string, int)>> graph, string start, string end)
{
    var visited = new HashSet<string>();
    var bestPath = new PathInfo { Path = new List<string>(), Distance = int.MaxValue };
    DFS(graph, start, end, visited, new List<string>(), 0, bestPath);
    return bestPath.Distance == int.MaxValue ? null : bestPath;
}
```
**tracking** variables:

1. visited: Keeps track of visited cities to avoid cycles.
2. bestPath: Stores the best path found (initially set to maximum distance).
3.  Calls the DFS (Depth-First Search) algorithm.
4.  Returns null if no path is found.

##### Main DFS algorithm which works in four steps:

1. Marks current city as visited and adds it to the path
2. If current city is the destination:
    * Updates best path if current distance is shorter
3. If not at destination:
    * Recursively explores all unvisited neighboring cities
4. Backtracks by removing the current city from visited and path

```dotnet
static void DFS(
    Dictionary<string, List<(string, int)>> graph,
    string current,
    string end,
    HashSet<string> visited,
    List<string> currentPath,
    int currentDistance,
    PathInfo bestPath)

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
```
By using a Depth First Search implementation it will find the shortest path between two cities represented in the graph.

Using this console application as an example:

```dotnet
string startCity = "New York";
string endCity = "Washington D.C.";
var bestPath = FindBestPath(graph, startCity, endCity);
```

**Best Path**
New York -> Philadelphia -> Washington D.C.
Total Distance: 234 miles