using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public static bool MapIsOpen = false;
    public GameObject mapUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (MapIsOpen) {
                CloseMap();
            } else {
                OpenMap();
            }
        }
    }

    public void CloseMap() {
        mapUI.SetActive(false);
        Time.timeScale = 1f;
        MapIsOpen = false;
    }

    void OpenMap() {
        mapUI.SetActive(true);
        // 1 is full speed, .5 half speed, 0 completely paused
        Time.timeScale = 0f;
        MapIsOpen = true;
    }

}
