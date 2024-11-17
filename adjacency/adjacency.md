#### Graph Representation

The console application represents the implementation of a directed graph and an ajacency matrix using a 2D array.
 

* Cities are represented as nodes.
* The adjacency matrix represents distances between the cities:
0: No direct connection.
\>0: Distance between the two cities.
* Adding Connections:
AddConnection: Adds a distance to the matrix for the two specified cities.
* Removing Connections:
RemoveConnection: Sets the corresponding matrix entries to 0.
* Displaying the Matrix:
DisplayMatrix: Prints the matrix with city names as headers.
* Checking Connections:
HasConnection: Returns true if the matrix entry for the cities is greater than 0.