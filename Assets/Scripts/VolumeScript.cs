// TODO: IMPLEMENT THIS BAD BOI. we have a slider that is sliding and an options menu that is optioning already.
// Probably need to grab all the music, all the steps, all the otehr sounds?
// We want a dif slider for each sound or just master volume?
// We need a dif more catch-all script than this for just master volume?

/*
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Music : MonoBehaviour {

    public AudioClip[] soundtrack;
    public Slider volumeSlider;

    AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();

        if (!audioSource.playOnAwake) {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update() {
        if (!audioSource.isPlaying) {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    void OnEnable() {
        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }

    //Called when Slider is moved
    void changeVolume(float sliderValue) {
        audioSource.volume = sliderValue;
    }

    void OnDisable() {
        //Un-Register Slider Events
        volumeSlider.onValueChanged.RemoveAllListeners();
    }
}
*/

/*
You use AudioSource.volume to change the volume. When you create a Slider, you can get the value of the slider with Slider.value. 
So, take Slider.value and assign it to AudioSource.volume.

To create s Slider, go to GameObject->UI->Slider. Make sure that Min Value is 0 and Max Value is 1. 
Also make sure that Whole Numbers check box is NOT checked. Drag the Slider to the volume Slider slot in this script from the Editor.

Note:

If you are going to use a component more than once, cache it to a global variable instead of doing 
GetComponent<AudioSource>() multiple times or using it in the Update() function.
*/