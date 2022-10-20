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
        
        // if (Input.GetKey("w")) {
        //     rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        // }

        // if (Input.GetKey("s")) {
        //     rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        // }

        // // TODO: switch these to rotate the player instead of move sideways!

        // if (Input.GetKey("a")) {
        //     rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }

        // if (Input.GetKey("d")) {
        //     rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }

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
