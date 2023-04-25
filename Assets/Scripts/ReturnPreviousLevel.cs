using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Also, you will have to reset Level.PreviousLevel to null if you go back to a menu / non level scene.

public class ReturnPreviousLevel : MonoBehaviour {
     public static string PreviousLevel { get; private set; }
     private void OnDestroy() {
        PreviousLevel = gameObject.scene.name;
     }
     
     private void Start() {
        // Debug.Log(Level.PreviousLevel);  // use this in any level to get the last level.
    }
 }