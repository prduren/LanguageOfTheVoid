using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject Note;
    public GameObject noteUI;
    public static bool NoteIsOpen = false;

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
            //execute note opening logic
            
            if (Input.GetMouseButtonDown(0)) {
                if (NoteIsOpen) {
                    CloseNote();
                } else {
                    OpenNote();
                }
            }
        }
        else {
            Debug.Log("not hit");
        }
    }

    public void CloseNote() {
        noteUI.SetActive(false);
        Time.timeScale = 1f;
        NoteIsOpen = false;
    }

    public void OpenNote() {
        noteUI.SetActive(true);
        Time.timeScale = 0f;
        NoteIsOpen = true;
    }

}
