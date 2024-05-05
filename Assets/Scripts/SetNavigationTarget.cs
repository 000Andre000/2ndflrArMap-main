using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshVisualizer : MonoBehaviour
{
    public GameObject[] destination;
    private LineRenderer lineRenderer;
    private NavMeshPath path;
    public GameObject source;
    public GameObject destinationObject;
    private int sourceIndex, destinationIndex;

    public void SetSource(int index)
    {
        sourceIndex = index;
        Debug.Log("si:" + sourceIndex);
    }

    public void SetDestination(int index)
    {
        destinationIndex = index;
        Debug.Log("di:" + destinationIndex);

    }


    void Start()
    {
        destination = GameObject.FindGameObjectsWithTag("destination");
      
        lineRenderer = GetComponent<LineRenderer>();
        path = new NavMeshPath();
    }

    private void Update()
    {
        source = destination[sourceIndex];
        destinationObject = destination[destinationIndex];
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
