using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sidewaysForce = 500f;

    // FixedUpdate called once a frame
    // Use FixedUpdate because Unity like it better for physics
    void FixedUpdate()
    {
        if (Input.GetKey("w")) {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s")) {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        // TODO: switch these to rotate the player instead of move sideways!

        if (Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d")) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

    }
}
