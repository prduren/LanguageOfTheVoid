using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTowards : MonoBehaviour
{

    GameObject shojiDoorLeft;
    AudioSource LevelMusic;
    float speed = .5f;
    Vector3 target;
    bool moveDoorFlag = false;
    string currentSceneName;


    // Start is called beforre the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        shojiDoorLeft = GameObject.Find("shoji door left (real)");
        if (currentSceneName == "L1") {
            LevelMusic = GameObject.Find("L1Music").GetComponent<AudioSource>();
        } else if (currentSceneName == "L2") {
            LevelMusic = GameObject.Find("L2Music").GetComponent<AudioSource>();
        } else if (currentSceneName == "L3") {
            LevelMusic = GameObject.Find("L2Music").GetComponent<AudioSource>();
        } else if (currentSceneName == "L4") {
            LevelMusic = GameObject.Find("L2Music").GetComponent<AudioSource>();
        } else if (currentSceneName == "L5") {
            LevelMusic = GameObject.Find("L2Music").GetComponent<AudioSource>();
        } else if (currentSceneName == "L6") {
            LevelMusic = GameObject.Find("L2Music").GetComponent<AudioSource>();
        }
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
                LevelMusic.Play();
            }
        }

        if (moveDoorFlag) {
            OpenDoor();
        }
            
    }

    void OpenDoor() {
        var step =  speed * Time.deltaTime; // calculate distance to move
        shojiDoorLeft.transform.position = Vector3.MoveTowards(shojiDoorLeft.transform.position, target, step); 
    }

}
