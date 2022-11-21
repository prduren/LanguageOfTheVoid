using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject Note;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Note");
    }

    // Update is called once per frame
    void Update()   
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // this assumes the mouse is at the center of the screen
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Note") {
            Debug.Log("hit");
        }
        else {
            Debug.Log("not hit");
        }
    }
}
