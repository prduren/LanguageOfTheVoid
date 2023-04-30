using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    GameObject[] MenuPeople;
    GameObject MenuCanvas;
    public GameObject optionsUI;

    // Start is called before the first frame update
    void Start()
    {
        MenuPeople = GameObject.FindGameObjectsWithTag("MenuPeople");
        MenuCanvas = GameObject.Find("MenuCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject person in MenuPeople) {
            person.transform.Rotate(0f, 0f, 6.0f * Time.deltaTime);
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("L1");
    }

    public void OpenOptions() {
        // enable options, disable menu
        MenuCanvas.SetActive(false);
        optionsUI.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
