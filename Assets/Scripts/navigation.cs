//using UnityEngine;
//using System.Linq;
//using System.Collections.Generic;

//public class Navigation : MonoBehaviour
//{
//    [SerializeField]
//    GameObject[] path;

//    [SerializeField]
//    GameObject[] destination;

//    GameObject src, dest;

//    float initialDistance;

//    int[,] adjacencyMatrix; // Adjacency matrix to represent connections between GameObjects

//    void Start()
//    {
//        // Find all GameObjects with the tag "path" and assign them to the 'path' array
//        path = GameObject.FindGameObjectsWithTag("path");
//        destination = GameObject.FindGameObjectsWithTag("destination");

//        // Concatenate the destination array to the path array
//        path = path.Concat(destination).ToArray();

//        // Sort the path array based on position
//        path = path.OrderBy(go => go.transform.position.x).ThenBy(go => go.transform.position.y).ThenBy(go => go.transform.position.z).ToArray();

//        // Access the second element
//        dest = destination[6];
//        src = destination[1];
//        initialDistance = FindDistance(src, dest);

//        // Create adjacency matrix
//        CreateAdjacencyMatrix();

//        // Debug log the adjacency matrix
//        DebugLogMatrix();

//        // Traverse the matrix from destination[0] to destination[15]
//        TraverseMatrix(destination[0], destination[15]);
//    }

//    void CreateAdjacencyMatrix()
//    {
//        int numNodes = path.Length;
//        adjacencyMatrix = new int[numNodes, numNodes];

//        for (int i = 0; i < numNodes; i++)
//        {
//            for (int j = 0; j < numNodes; j++)
//            {
//                if (i == j)
//                {
//                    adjacencyMatrix[i, j] = 0; // No edge between a node and itself
//                }
//                else
//                {
//                    // Check if there is a direct path between the GameObjects with minimum distance
//                    if (HasDirectPathWithMinimumDistance(path[i], path[j]))
//                    {
//                        adjacencyMatrix[i, j] = 1; // Edge exists
//                        adjacencyMatrix[j, i] = 1; // Bidirectional edge
//                    }
//                    else
//                    {
//                        adjacencyMatrix[i, j] = 0; // No edge
//                        adjacencyMatrix[j, i] = 0; // No bidirectional edge
//                    }
//                }
//            }
//        }
//    }

//    bool HasDirectPathWithMinimumDistance(GameObject x, GameObject y)
//    {
//        // Calculate the distance between x and y
//        float distance = FindDistance(x, y);

//        // Check if the distance is minimum
//        if (distance == FindMinimumDistance(x))
//        {
//            return true;
//        }
//        return false;
//    }

//    float FindMinimumDistance(GameObject node)
//    {
//        float minDistance = float.MaxValue;

//        // Iterate through all other nodes to find the minimum distance from 'node'
//        foreach (GameObject otherNode in path)
//        {
//            if (otherNode != node)
//            {
//                float distance = FindDistance(node, otherNode);
//                if (distance < minDistance)
//                {
//                    minDistance = distance;
//                }
//            }
//        }

//        return minDistance;
//    }

//    void DebugLogMatrix()
//    {
//        int numRows = adjacencyMatrix.GetLength(0);
//        int numCols = adjacencyMatrix.GetLength(1);

//        Debug.Log("Adjacency Matrix:");

//        for (int i = 0; i < numRows; i++)
//        {
//            string row = "";
//            for (int j = 0; j < numCols; j++)
//            {
//                row += adjacencyMatrix[i, j] + " ";
//            }
//            Debug.Log(row);
//        }
//    }

//    void TraverseMatrix(GameObject start, GameObject end)
//    {
//        int startIndex = System.Array.IndexOf(path, start);
//        int endIndex = System.Array.IndexOf(path, end);

//        HashSet<int> visited = new HashSet<int>();
//        Stack<int> stack = new Stack<int>();

//        stack.Push(startIndex);

//        while (stack.Count > 0)
//        {
//            int currentNodeIndex = stack.Pop();
//            visited.Add(currentNodeIndex);

//            // Check if the current node is the destination
//            if (currentNodeIndex == endIndex)
//            {
//                Debug.Log("Reached destination!");
//                return;
//            }

//            for (int i = 0; i < path.Length; i++)
//            {
//                // Check if there's a connection between the current node and the next node
//                if (adjacencyMatrix[currentNodeIndex, i] == 1 && !visited.Contains(i))
//                {
//                    stack.Push(i);
//                }
//            }
//        }

//        Debug.Log("Destination not reachable!");
//    }

//    float FindDistance(GameObject x, GameObject y)
//    {
//        float distance = Vector3.Distance(x.transform.position, y.transform.position);
//        return distance;
//    }

//    // Other methods (navigate, GetNeighbors, Update) remain unchanged...
//}
