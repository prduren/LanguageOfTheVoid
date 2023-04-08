using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingPeople : MonoBehaviour
{

    GameObject[] MarchingPeoples;
    Transform currentWaypoint;
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        MarchingPeoples = GameObject.FindGameObjectsWithTag("MarchingPeople");

        // set init position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // set the next waypoint target
        // currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        // transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold) {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
    }
}
