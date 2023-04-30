// TODO: toggle full screen (already done in pause menu)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    GameObject[] MenuPeople;
    GameObject MenuCanvas;
    public GameObject optionsUI;
    public GameObject menuUI;
    public GameObject stepsOnImage;
    public GameObject musicOnImage;
    public GameObject fullScreenImage;
    AudioSource stepsAudioSource;
    AudioSource musicAudioSource;
    public Sprite onSwitch;
    public Sprite offSwitch;

    // Start is called before the first frame update
    void Start()
    {
        MenuPeople = GameObject.FindGameObjectsWithTag("MenuPeople");
        MenuCanvas = GameObject.Find("MenuCanvas");
        stepsAudioSource = GameObject.Find("woodStep").GetComponent<AudioSource>();
        musicAudioSource = GameObject.Find("L2Music").GetComponent<AudioSource>();
        if (ApplicationData.StepsSoundOnImage == true) {
            stepsOnImage.GetComponent<Image>().sprite = onSwitch;
        } else if (ApplicationData.StepsSoundOnImage == false) {
            stepsOnImage.GetComponent<Image>().sprite = offSwitch;
        }
        if (ApplicationData.MusicSoundOnImage == true) {
            musicOnImage.GetComponent<Image>().sprite = onSwitch;
        } else if (ApplicationData.MusicSoundOnImage == false) {
            musicOnImage.GetComponent<Image>().sprite = offSwitch;
        }
        if (ApplicationData.FullScreenMode) {
            Screen.fullScreen = ApplicationData.FullScreenMode;
            fullScreenImage.GetComponent<Image>().sprite = onSwitch;
        } else if (!ApplicationData.FullScreenMode) {
            Screen.fullScreen = ApplicationData.FullScreenMode;
            fullScreenImage.GetComponent<Image>().sprite = offSwitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject person in MenuPeople) {
            person.transform.Rotate(0f, 0f, 6.0f * Time.deltaTime);
        }
    }

    public void Back() {
        menuUI.SetActive(true);
        optionsUI.SetActive(false);
    }

    public void StepsActive() {
        if (stepsAudioSource.mute) {
            stepsOnImage.GetComponent<Image>().sprite = onSwitch;
            stepsAudioSource.mute = false;
            ApplicationData.StepsSoundOn = false;
            ApplicationData.StepsSoundOnImage = true;
        } else {
            stepsOnImage.GetComponent<Image>().sprite = offSwitch;
            stepsAudioSource.mute = true;
            ApplicationData.StepsSoundOn = true;
            ApplicationData.StepsSoundOnImage = false;
        }
    }

    public void MusicActive() {
        if (musicAudioSource.mute) {
            musicOnImage.GetComponent<Image>().sprite = onSwitch;
            musicAudioSource.mute = false;
            ApplicationData.MusicSoundOn = false;
            ApplicationData.MusicSoundOnImage = true;

        } else {
            musicOnImage.GetComponent<Image>().sprite = offSwitch;
            musicAudioSource.mute = true;
            ApplicationData.MusicSoundOn = true;
            ApplicationData.MusicSoundOnImage = false;
        }
    }

    public void ToggleFullScreen() {
        if (Screen.fullScreen) {
            fullScreenImage.GetComponent<Image>().sprite = offSwitch;
            ApplicationData.FullScreenMode = false;
            Screen.fullScreen = false;
        } else if (!Screen.fullScreen) {
            fullScreenImage.GetComponent<Image>().sprite = onSwitch;
            ApplicationData.FullScreenMode = true;
            Screen.fullScreen = true;
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
