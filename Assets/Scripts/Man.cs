using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool InitVoidFlag = false;
    bool L2SceneActiveFlag = false;
    string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Man1 = GameObject.Find("man1");
        originalPos = new Vector3(26, 0, -5);
        Man1Parent = GameObject.Find("man1Parent");
        VoidHome = GameObject.Find("VoidHome");
        Void = GameObject.Find("void");
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        if (currentSceneName == "L2") {
            L2SceneActiveFlag = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(L2SceneActiveFlag);
        if (L2SceneActiveFlag) {
            Man1.transform.Rotate(0, 0, 1);
        }

        distanceFromVoidHome = Vector3.Distance(Man1.transform.position, VoidHome.transform.position);
        playerDistanceFromMan = Vector3.Distance(originalPos, Player.transform.position);

        // grab the man if Player is close enough
        if ((Input.GetKeyDown(KeyCode.V)) & (playerDistanceFromMan < 3)) {
            manAttached = true;
        }

        // if grabbing man
        if (manAttached) {
            Man1.transform.SetParent(Player.transform);
            Man1.transform.RotateAround(Player.transform.position, Vector3.up, 200f * Time.deltaTime);
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
            InitVoidFlag = true;
            Vector3 vec = new Vector3(0, 0, 0);
            Man1.transform.localScale = vec;
            Void.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (InitVoidFlag) {
            SpinVoid();
        }


    }

    void SpinVoid() {
        Void.transform.Rotate(0f, 0f, 6.0f * voidRotationsPerMinute * Time.deltaTime);
    }

}
