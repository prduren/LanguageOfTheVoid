using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteHallway : MonoBehaviour
{

    GameObject ResetPoint;
    GameObject GoBegin;
    GameObject Player;
    public GameObject WinterThings;
    public GameObject SpringThings;
    float distanceFromGoBegin;
    private Vector3 playerVelocity;
    bool teleportedFlag;

    void Start()
    {
        ResetPoint = GameObject.Find("ResetPoint");
        Player = GameObject.Find("Player");
        GoBegin = GameObject.Find("GoBegin");
        teleportedFlag = false;
    }

    void Update()
    {
        distanceFromGoBegin = Vector3.Distance(Player.transform.position, GoBegin.transform.position);
        if (distanceFromGoBegin < 1.5) {
            playerVelocity = Player.GetComponent<Rigidbody>().velocity;
            if (WinterThings.activeSelf) {
                WinterThings.SetActive(false);
                SpringThings.SetActive(true);
            } else if (SpringThings.activeSelf) {
                SpringThings.SetActive(false);
                WinterThings.SetActive(true);
            }
            Player.transform.position = ResetPoint.transform.position;
            teleportedFlag = true;
        }
        if (teleportedFlag) {
            Player.GetComponent<Rigidbody>().velocity = playerVelocity;
            teleportedFlag= false; 
        }

    }
}
