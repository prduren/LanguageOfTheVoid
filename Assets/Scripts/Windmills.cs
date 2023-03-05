using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmills : MonoBehaviour
{
    
    GameObject[] windmills;

    void Start()
    {
        Debug.Log("hi");
        windmills = GameObject.FindGameObjectsWithTag("windmill");
        foreach(GameObject wm in windmills) {
            Animator wmAnimator = wm.GetComponent<Animator>();
            wmAnimator.speed = 20;
            Debug.Log(wmAnimator.speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
