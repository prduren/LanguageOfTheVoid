using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        // lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

    }
}
