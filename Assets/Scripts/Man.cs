using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{

    GameObject Player;
    GameObject Man1;
    GameObject Man1Parent;
    Vector3 originalPos;
    bool manAttached = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Man1 = GameObject.Find("man1");
        originalPos = new Vector3(26, 0, -5);
        Man1Parent = GameObject.Find("man1Parent");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V)) {
            manAttached = true;
        }

        // if (Input.GetKeyDown(KeyCode.C)) {
               //  manAttached = false;
        //}

        if (manAttached) {
            Man1.transform.SetParent(Player.transform);
            if (Input.GetKeyDown(KeyCode.C)) {
                manAttached = false;
        }
        }
        else if (!manAttached) {
                Man1.transform.position = originalPos;
                Man1.transform.SetParent(Man1Parent.transform);
        }

    }

}
