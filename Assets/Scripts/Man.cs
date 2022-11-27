using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{

    GameObject Player;
    GameObject Man1;
    GameObject Man1Parent;
    GameObject VoidHome;
    GameObject Void;
    Vector3 originalPos;
    float distanceFromVoidHome;
    float playerDistanceFromMan;
    bool manAttached = false;
    float voidRotationsPerMinute = 200.0f;
    // for demo only
    GameObject[] demoObjects;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Man1 = GameObject.Find("man1");
        originalPos = new Vector3(26, 0, -5);
        Man1Parent = GameObject.Find("man1Parent");
        VoidHome = GameObject.Find("VoidHome");
        Void = GameObject.Find("void");
        // for demo only
        // demoObjects = GameObject.FindGameObjectsWithTag("demo");
    }

    // Update is called once per frame
    void Update()
    {

        distanceFromVoidHome = Vector3.Distance(Man1.transform.position, VoidHome.transform.position);
        playerDistanceFromMan = Vector3.Distance(originalPos, Player.transform.position);

        // grab the man if Player is close enough
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
            InitVoid();
            Vector3 vec = new Vector3(0, 0, 0);
            Man1.transform.localScale = vec;
        }
    }

    void InitVoid() {
        Void.GetComponent<SpriteRenderer>().enabled = true;
        Void.transform.Rotate(0f, 0f, 6.0f * voidRotationsPerMinute * Time.deltaTime);
    }

}
