using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{

    GameObject Player;
    GameObject Man1;
    GameObject Man1Parent;
    GameObject VoidHome;
    Vector3 originalPos;
    float distanceFromVoidHome;
    float playerDistanceFromMan;
    bool manAttached = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Man1 = GameObject.Find("man1");
        originalPos = new Vector3(26, 0, -5);
        Man1Parent = GameObject.Find("man1Parent");
        VoidHome = GameObject.Find("VoidHome");
    }

    // Update is called once per frame
    void Update()
    {

        distanceFromVoidHome = Vector3.Distance(Man1.transform.position, VoidHome.transform.position);
        playerDistanceFromMan = Vector3.Distance(originalPos, Player.transform.position);

        // grab the man
        if ((Input.GetKeyDown(KeyCode.V)) & (playerDistanceFromMan < 3)) {
            manAttached = true;
        }


        // if grabbing man
        if (manAttached) {
            Man1.transform.SetParent(Player.transform);
            if (Input.GetKeyDown(KeyCode.C)) {
                manAttached = false;
        }
        // if not grabbing man / if let go of man
        }
        else if (!manAttached) {
                Man1.transform.position = originalPos;
                Man1.transform.SetParent(Man1Parent.transform);
        }

        // if man is close enough to VoidHome then end level
        if (distanceFromVoidHome < 3) {
            Debug.Log("end level");
        }
    }

}
