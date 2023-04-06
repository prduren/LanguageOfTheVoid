using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    float distanceFromBoatEndPoint;
    GameObject Player;
    GameObject BlueMan;
    GameObject BoatSpawn;
    GameObject BoatEndPoint;
    public bool enteredBoat;
    string currentActiveScene;
    bool L5ActiveFlag = false;

    void Start()
    {   
        Scene currentScene = SceneManager.GetActiveScene();
        string currentActiveScene = currentScene.name;
        Debug.Log(currentScene.name);

        // set init position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

        distanceFromFlag = 0f;
        distanceFromBoatEndPoint = 0f;
        enteredBoat = false;
        boatDoor = GameObject.FindGameObjectsWithTag("BoatDoor");
        BlueManFlag = GameObject.Find("BlueManFlag");
        Player = GameObject.Find("Player");
        Debug.Log(currentActiveScene);
        if (currentActiveScene == "L5") {
            BlueMan = GameObject.FindGameObjectWithTag("blueMan");
            L5ActiveFlag = true;
        }
        BoatSpawn = GameObject.Find("BoatSpawn");
        BoatEndPoint = GameObject.Find("BoatEndPoint");
        
    }

    void Update()
    {         
        if (L5ActiveFlag) {
            // if holding blue man and near boat, open boat door
            distanceFromFlag = Vector3.Distance(BlueManFlag.transform.position, BlueMan.transform.position);
            distanceFromBoatEndPoint = Vector3.Distance(Player.transform.position, BoatEndPoint.transform.position);
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
                if (distanceFromBoatEndPoint < 5) {
                    enteredBoat = false;
                }
            }
        }
    }
}
