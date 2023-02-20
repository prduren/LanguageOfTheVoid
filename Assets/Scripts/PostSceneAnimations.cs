using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostSceneAnimations : MonoBehaviour
{

    public GameObject postSceneImage;

    void Start()
    {
        postSceneImage.SetActive(true);
        Time.timeScale = 1f;

    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space)) {
            postSceneImage.SetActive(false);
        }
    } 
}
