using UnityEngine;

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
    public bool CanMove = false;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        rb.freezeRotation = true;
        rb = GetComponent<Rigidbody>();
        YesWatched = GameObject.Find("YesWatched");
        StartBox = GameObject.Find("StartBox");
    }
    // FixedUpdate called once a frame
    // Use FixedUpdate because Unity like it better for physics
    void FixedUpdate()
    
    {
        if (CanMove) {
            MyInput();
            MovePlayer();
        }
        
    }

    void Update() {
        EnablePlayerMovement();
    }

    private void MyInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
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
        else {
            Debug.Log("no" + Input.mousePosition);
        }
    }

}
