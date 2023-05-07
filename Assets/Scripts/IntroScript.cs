using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {
    public Animator animator;
    GameObject sceneFaderObj;
    GameObject rawImage;
    AudioSource IntroMusic;

    void Start() {
        sceneFaderObj = GameObject.Find("SceneFaderScript");
        rawImage = GameObject.Find("RawImage");
        IntroMusic = GameObject.Find("IntroMusic").GetComponent<AudioSource>();
        IntroMusic.Play();
    }

    void Update(){
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
                Initiate.Fade("Menu", Color.black, 3f);
            }
    }
}
