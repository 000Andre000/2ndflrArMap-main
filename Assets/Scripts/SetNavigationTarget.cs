using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshVisualizer : MonoBehaviour
{
    [SerializeField] private int src, dest;
    public GameObject[] destination;
    private LineRenderer lineRenderer;
    private NavMeshPath path;
    private GameObject source;

    void Start()
    {
        destination = GameObject.FindGameObjectsWithTag("destination");
        source = destination[src];
        GameObject destinationObject = destination[dest];
        lineRenderer = GetComponent<LineRenderer>();
        path = new NavMeshPath();
        DrawNavMesh(destinationObject);
    }

    void DrawNavMesh(GameObject destinationObject)
    {
        NavMesh.CalculatePath(source.transform.position, destinationObject.transform.position, NavMesh.AllAreas, path);

        List<Vector3> waypoints = new List<Vector3>();

        waypoints.Add(new Vector3(source.transform.position.x, 0.5f, source.transform.position.z));

        foreach (Vector3 corner in path.corners)
        {
            waypoints.Add(new Vector3(corner.x, 0.5f, corner.z)); // Setting Y position to 0
        }

        waypoints.Add(new Vector3(destinationObject.transform.position.x, 0.5f, destinationObject.transform.position.z)); // Setting Y position to 0

        lineRenderer.positionCount = waypoints.Count;
        lineRenderer.SetPositions(waypoints.ToArray());
        lineRenderer.enabled = true;
    }
}
