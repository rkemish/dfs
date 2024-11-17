using System;

class Program
{
    static void Main()
    {
        // Step 1: Define cities
        string[] cityNames = { "New York", "Boston", "Philadelphia", "Washington D.C.", "Chicago" };

        // Step 2: Create a graph
        Graph graph = new Graph(cityNames);

        // Step 3: Add connections (edges) between cities
        graph.AddConnection("New York", "Boston", 215);       // New York to Boston (215 miles)
        graph.AddConnection("New York", "Philadelphia", 94);  // New York to Philadelphia (94 miles)
        graph.AddConnection("Philadelphia", "Washington D.C.", 140); // Philadelphia to D.C. (140 miles)
        graph.AddConnection("New York", "Washington D.C.", 225); // New York to D.C. (225 miles)
        graph.AddConnection("Chicago", "Washington D.C.", 700); // Chicago to D.C. (700 miles)

        // Step 4: Display the adjacency matrix
        graph.DisplayMatrix();

        // Step 5: Check if there is a connection
        Console.WriteLine($"\nIs there a connection between New York and Boston? {graph.HasConnection("New York", "Boston")}");
        Console.WriteLine($"Is there a connection between Boston and Chicago? {graph.HasConnection("Boston", "Chicago")}");

        // Step 6: Remove a connection and display the matrix again
        Console.WriteLine("\nRemoving connection between New York and Boston...");
        graph.RemoveConnection("New York", "Boston");
        graph.DisplayMatrix();
    }
}