
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


##### Main Algorithm - FindBestPathIterative
```dotnet
 static PathInfo FindBestPathIterative(Dictionary<string, List<(string, int)>> graph, string start, string end)
    {
        var visited = new HashSet<string>();
        var stack = new Stack<(string currentCity, List<string> path, int distance)>();

        // Each element in the stack is a tuple containing the current city, the path taken to reach that city, and the total distance traveled so far.

        //  The stack is initially populated with the start city, an empty path, and a distance of zero. 

        // A PathInfo object bestPath is also initialized to store the shortest path found, with its distance set to int.MaxValue to indicate that no path has been found yet.

        stack.Push((start, new List<string> { start }, 0));
        PathInfo bestPath = new PathInfo { Path = new List<string>(), Distance = int.MaxValue };

        // Main Loop
        while (stack.Count > 0)
        {
            // Step 1: Pop the top node
            var (currentCity, currentPath, currentDistance) = stack.Pop();

            // Step 2: If we've already visited the city, skip it
            // Path Processing
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
                // Neighbor Processing
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
````

##### This implementation uses a stack to manage the search process
##### Each stack entry contains:

* Current city
* Path taken so far
* Total distance traveled

##### Main Loop
* Continues until stack is empty
* Pops the top entry for processing

##### Path Processing
* Checks if city was already visited
* Updates best path if we've reached destination with shorter distance

#####  Neighbor Processing
For each unvisited neighbor:

* Creates new path including this neighbor
* Adds to stack with updated distance

Usage Example:

````dotnet
Copystring startCity = "New York";
string endCity = "Washington D.C.";
var bestPath = FindBestPathIterative(graph, startCity, endCity);
````

For these inputs, it would find the shortest path from NY to DC:
Best Path:
New York -> Philadelphia -> Washington D.C.
Total Distance: 234 miles

##### Key Differences from Recursive Version:

* Uses a stack instead of recursion
* Maintains path history explicitly in the stack
* May be more memory efficient for very deep paths
* Easier to debug as you can inspect the stack at any point