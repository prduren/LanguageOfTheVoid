using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed;
    public float horizontalInput;
    public float verticalInput;
    public Transform orientation;
    GameObject YesWatched;
    GameObject StartBox;
    Vector3 moveDirection;
    string currentSceneName;
    public bool CanMove = false;
    GameObject Player;

    // waypoint logic
    Transform currentWaypoint;
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    // float distanceFromStairBeginning;
    // GameObject[] stairBeginnings;
    // GameObject[] stairEndings;
    // GameObject[] waypointObjects;
    // float distanceFromStairEnding;
    // bool startedStairAnimation = false;

    void Start () {
        rb.freezeRotation = true;
        rb = GetComponent<Rigidbody>();
        YesWatched = GameObject.Find("YesWatched");
        StartBox = GameObject.Find("StartBox");
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        Player = GameObject.Find("Player");
        if (currentSceneName != "L1") { 
            CanMove = true;
        }
        // waypoint logic
        // currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        // transform.position = currentWaypoint.position;
        // stairBeginnings = GameObject.FindGameObjectsWithTag("StairBeginning");
        // stairEndings = GameObject.FindGameObjectsWithTag("StairEnding");
        // waypointObjects = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // Use FixedUpdate because Unity like it better for physics
    void FixedUpdate() {
        rb.AddForce(Physics.gravity*rb.mass);
        if (CanMove) {
            MyInput();
            MovePlayer();
        }
    }

    void Update() {
        if (currentSceneName == "L1" ) {
            EnablePlayerMovement();
        }

        // waypoint logic
        /* foreach (GameObject sb in stairBeginnings) {
            distanceFromStairBeginning = Vector3.Distance(Player.transform.position, sb.transform.position);
            Debug.Log(distanceFromStairBeginning);
            if (distanceFromStairBeginning < 1f) {
                // TODO: set the new waypoints
                // TODO: closest waypoint are the waypoints u wanna use?
                    GameObject GetClosestWaypoint(GameObject[] waypointObjects) {
                        GameObject tMin = null;
                        float minDist = Mathf.Infinity;
                        Vector3 currentPos = Player.transform.position;
                        foreach (GameObject t in waypointObjects) {
                            float dist = Vector3.Distance(t.transform.position, currentPos);
                            if (dist < minDist) {
                                tMin = t;
                                minDist = dist;
                            }
                        }
                        return tMin;
                    }
                waypoints = GetClosestWaypoint(waypointObjects);
                startedStairAnimation = true;
            }
        }
        if (startedStairAnimation) {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, currentWaypoint.position, movingSpeed * Time.deltaTime);
            if (Vector3.Distance(Player.transform.position, currentWaypoint.position) < distanceThreshold) {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
            foreach(GameObject se in stairEndings) {
                distanceFromStairEnding = Vector3.Distance(Player.transform.position, se.transform.position);
                if (distanceFromStairEnding < 0.5f) {
                    startedStairAnimation = false;
                }
            }
        } */
        
    }

    private void MyInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput != 0) {
            rb.drag = 12;
        }
        else {
            rb.drag = 5;
        }
    }

    private void MovePlayer() {
        // calculate player movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void EnablePlayerMovement() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // this assumes the mouse is at the center of the screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "YesWatched") {
            if (Input.GetMouseButtonDown(0)) {
                CanMove = true;
                StartBox.SetActive(false);
            }
        }
    }

}
