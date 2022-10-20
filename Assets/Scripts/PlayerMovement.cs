using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float moveSpeed;
    public float horizontalInput;
    public float verticalInput;

    public Transform orientation;

    Vector3 moveDirection;

    void Start () {
        rb.freezeRotation = true;
        rb = GetComponent<Rigidbody>();
    }
    // FixedUpdate called once a frame
    // Use FixedUpdate because Unity like it better for physics
    void FixedUpdate()
    
    {
        MyInput();
        MovePlayer();
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

}
