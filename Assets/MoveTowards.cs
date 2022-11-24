using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    GameObject shojiDoorLeft;
    AudioSource L1Music;
    float speed = .5f;
    Vector3 target;
    bool moveDoorFlag = false;

    // Start is called beforre the first frame update
    void Start()
    {
        shojiDoorLeft = GameObject.Find("shoji door left (real)");
        L1Music = GameObject.Find("L1Music").GetComponent<AudioSource>();
        target = new Vector3(23.16f,-.17f,-6.2f);
    }

    // Update is called once per frame
    void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // this assumes the mouse is at the center of the screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "shojiDoor") {
            if (Input.GetMouseButtonDown(0)) {
                moveDoorFlag = true;
                // play audio
            }
        }

        if (moveDoorFlag) {
            OpenDoor();
        }
            
    }

    void OpenDoor() {
        var step =  speed * Time.deltaTime; // calculate distance to move
        shojiDoorLeft.transform.position = Vector3.MoveTowards(shojiDoorLeft.transform.position, target, step); 
        Debug.Log("doorPos:" + shojiDoorLeft.transform.position + "targetPos:" + target);
    }

}
