using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{

    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    /// current waypoint target that object is moving towards
    Transform currentWaypoint;

    GameObject[] boatDoor;
    GameObject BlueManFlag;
    float distanceFromFlag;
    GameObject Player;
    GameObject BoatSpawn;
    public bool enteredBoat;


    void Start()
    {

        // set init position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

        distanceFromFlag = 0;
        enteredBoat = false;
        boatDoor = GameObject.FindGameObjectsWithTag("BoatDoor");
        BlueManFlag = GameObject.Find("BlueManFlag");
        Player = GameObject.Find("Player");
        BoatSpawn = GameObject.Find("BoatSpawn");
        
    }

    void Update()
    {
        // if holding blue man and near boat, open boat door
        distanceFromFlag = Vector3.Distance(BlueManFlag.transform.position, Player.transform.position);
        if (distanceFromFlag < 3) {
            enteredBoat = true;
        }
        if (enteredBoat) {
            Player.transform.position = BoatSpawn.transform.position;
            foreach(GameObject piece in boatDoor) {
                piece.GetComponent<MeshRenderer>().enabled = false;
                if (piece.GetComponent<BoxCollider>()) {
                    piece.GetComponent<BoxCollider>().enabled = false;
                }
                if (piece.GetComponent<MeshCollider>()) {
                    piece.GetComponent<MeshCollider>().enabled = false;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold) {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
        }
    }
}
