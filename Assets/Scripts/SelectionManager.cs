using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject Note;
    GameObject Diagram;
    GameObject EndNote;
    GameObject CreditNote;
    GameObject Player;
    public static bool NoteIsOpen = false;
    public GameObject noteUI;
    float distanceFromNote;
    float distanceFromDiagram;
    float distanceFromEndNote;
    string currentSceneName;
    bool L9Flag;
    GameObject PauseCanvas;

    void Start()
    {
        L9Flag = false;
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        Note = GameObject.FindGameObjectWithTag("Note");
        Diagram = GameObject.FindGameObjectWithTag("Diagram");
        if (currentSceneName == "L9") {
            L9Flag = true;
            EndNote = GameObject.FindGameObjectWithTag("EndNote");
        }
        Player = GameObject.Find("Player");
        PauseCanvas = GameObject.Find("PauseCanvas");

    }

    // Update is called once per frame
    void Update()   
    {

        distanceFromNote = Vector3.Distance(Player.transform.position, Note.transform.position);
        distanceFromDiagram = Vector3.Distance(Player.transform.position, Diagram.transform.position);

        if (distanceFromNote < 1 && Input.GetMouseButtonDown(0) && PauseCanvas.GetComponent<PauseMenu>().GameIsPaused == false) {
            if (NoteIsOpen) {
                    CloseNote();
                } else {
                    OpenNote();
                }
        }
        
        if (distanceFromDiagram < 2 && Input.GetMouseButtonDown(0) && PauseCanvas.GetComponent<PauseMenu>().GameIsPaused == false) {
            if (NoteIsOpen) {
                    CloseNote();
                } else {
                    OpenNote();
                }
        }

        if (L9Flag) {
            distanceFromEndNote = Vector3.Distance(Player.transform.position, EndNote.transform.position);

            if (distanceFromEndNote < 2 && Input.GetMouseButtonDown(0) && PauseCanvas.GetComponent<PauseMenu>().GameIsPaused == false) {
                if (NoteIsOpen) {
                    CloseNote();
                } else {
                    OpenNote();
                }
            }
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // this assumes the mouse is at the center of the screen
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Note") {
            //execute note opening logic
            
            if (Input.GetMouseButtonDown(0) && PauseCanvas.GetComponent<PauseMenu>().GameIsPaused == false) {
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
