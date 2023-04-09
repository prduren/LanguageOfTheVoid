using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject Note;
    GameObject Diagram;
    GameObject Player;
    public static bool NoteIsOpen = false;
    public GameObject noteUI;
    float distanceFromNote;
    float distanceFromDiagram;

    void Start()
    {
        Note = GameObject.FindGameObjectWithTag("Note");
        Diagram = GameObject.FindGameObjectWithTag("Diagram");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()   
    {

        distanceFromNote = Vector3.Distance(Player.transform.position, Note.transform.position);
        distanceFromDiagram = Vector3.Distance(Player.transform.position, Diagram.transform.position);


        Debug.Log(distanceFromNote);
        if (distanceFromNote < 1 && Input.GetMouseButtonDown(0)) {
            if (NoteIsOpen) {
                    CloseNote();
                } else {
                    OpenNote();
                }
        }
        
        if (distanceFromDiagram < 1 && Input.GetMouseButtonDown(0)) {
            if (NoteIsOpen) {
                    CloseNote();
                } else {
                    OpenNote();
                }
        }

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
