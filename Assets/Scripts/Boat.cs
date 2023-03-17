using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{

    GameObject[] boatDoor;

    void Start()
    {
        boatDoor = GameObject.FindGameObjectsWithTag("BoatDoor");
        foreach(GameObject piece in boatDoor) {
            piece.GetComponent<MeshRenderer>().enabled = false;
            if (piece.GetComponent<BoxCollider>()) {
                piece.GetComponent<BoxCollider>().enabled = false;
            }
            if (piece.GetComponent<MeshCollider>()) {
                piece.GetComponent<MeshCollider>().enabled = false;
            }
        }
    }

    void Update()
    {
        
    }
}
