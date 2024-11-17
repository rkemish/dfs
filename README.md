# DFS or Depth First Search traversal Graph ADT

Depth-First Search (DFS) is a graph traversal algorithm that starts at a node, explores as far as possible along each path, and backtracks when no more unvisited nodes are available.

There are two possible ways to implement DFS: recursive and iterative (using an explicit stack).

1. Start at the root or any arbitrary node.
2. Visit the node.
3. Recursively or iteratively visit all its unvisited neighbors.
4. Backtrack if no more neighbors are left.

The concept of backtracking in DFS arises because the algorithm explores one path fully before trying alternate paths.

When DFS reaches a dead-end (a node with no unvisited neighbors), it “backtracks” to previously visited nodes to explore other unvisited neighbors, if any.

DFS is inherently designed to go “as deep as possible” along a branch before exploring alternate paths. Without backtracking, DFS would be unable to return to the decision point where it chose a specific path and examine other possibilities.

 [DFS Recursive Implementation](/recursive/recursive.md) </br>
 [DFS Iterative Implementation](/iterative/iterative.md)</br>
 [DFS Recursive Implementation](/adjacency/adjacency.md)</br>