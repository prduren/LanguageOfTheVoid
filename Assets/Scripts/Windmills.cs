using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmills : MonoBehaviour
{
    
    GameObject[] windmills;

    void Start()
    {
        windmills = GameObject.FindGameObjectsWithTag("windmill");
        foreach(GameObject wm in windmills) {
            Animator wmAnimator = wm.GetComponent<Animator>();
            wmAnimator.speed = 40;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
