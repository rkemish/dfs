class Graph
{
    private string[] cities; // List of city names
    private int[,] adjacencyMatrix; // 2D array to store distances
    private int numberOfCities; // Number of cities

    public Graph(string[] cityNames)
    {
        cities = cityNames;
        numberOfCities = cityNames.Length;
        adjacencyMatrix = new int[numberOfCities, numberOfCities];
    }

    // Add a connection (edge) between two cities
    public void AddConnection(string city1, string city2, int distance)
    {
        int index1 = Array.IndexOf(cities, city1);
        int index2 = Array.IndexOf(cities, city2);

        if (index1 == -1 || index2 == -1)
        {
            Console.WriteLine("Error: One or both cities not found.");
            return;
        }

        adjacencyMatrix[index1, index2] = distance; // Directed connection
        adjacencyMatrix[index2, index1] = distance; // Undirected connection
    }

    // Remove a connection (edge) between two cities
    public void RemoveConnection(string city1, string city2)
    {
        int index1 = Array.IndexOf(cities, city1);
        int index2 = Array.IndexOf(cities, city2);

        if (index1 == -1 || index2 == -1)
        {
            Console.WriteLine("Error: One or both cities not found.");
            return;
        }

        adjacencyMatrix[index1, index2] = 0;
        adjacencyMatrix[index2, index1] = 0;
    }

    // Display the adjacency matrix
    public void DisplayMatrix()
    {
        Console.WriteLine("\nAdjacency Matrix:");
        Console.Write("      ");
        foreach (var city in cities)
        {
            Console.Write(city.PadRight(10));
        }
        Console.WriteLine();

        for (int i = 0; i < numberOfCities; i++)
        {
            Console.Write(cities[i].PadRight(6));
            for (int j = 0; j < numberOfCities; j++)
            {
                Console.Write(adjacencyMatrix[i, j].ToString().PadRight(10));
            }
            Console.WriteLine();
        }
    }

    // Check if there is a connection between two cities
    public bool HasConnection(string city1, string city2)
    {
        int index1 = Array.IndexOf(cities, city1);
        int index2 = Array.IndexOf(cities, city2);

        if (index1 == -1 || index2 == -1)
        {
            Console.WriteLine("Error: One or both cities not found.");
            return false;
        }

        return adjacencyMatrix[index1, index2] > 0;
    }
}