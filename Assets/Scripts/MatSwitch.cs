using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatSwitch : MonoBehaviour
{
    void Start()
    {

        // GameObject MatSwitchButton;
        Debug.Log("hi");
        object[] obj = GameObject.FindObjectsOfType(typeof (GameObject));
        foreach (object o in obj) {
            Debug.Log(o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // this assumes the mouse is at the center of the screen
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "MatSwitchButton") {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("nice");
            }
        }
    }
}
