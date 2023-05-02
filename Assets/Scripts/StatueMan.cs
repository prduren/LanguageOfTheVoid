using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueMan : MonoBehaviour
{

    GameObject Statue;
    public GameObject LeftShoulder;
    public GameObject RightShoulder;
    public GameObject Head;
    public GameObject Spine;
    public GameObject LeftThigh;
    public GameObject RightThigh;
    string currentSceneName;


    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        Statue = GameObject.Find("Statue Man");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSceneName == "L6") {
            LeftShoulder.transform.Rotate(0f, -.1f, 0f  * Time.deltaTime);
            RightShoulder.transform.Rotate(0f, .1f, 0f * Time.deltaTime);
        } else if (currentSceneName == "L7") {
            Head.transform.Rotate(0f, 5f, 0f * Time.deltaTime);
            Spine.transform.Rotate(0f, -5f, 0f * Time.deltaTime);
        } else if (currentSceneName == "L8") {
            Head.transform.Rotate(0f, 5f, 0f * Time.deltaTime);
            Spine.transform.Rotate(0f, -5f, 0f * Time.deltaTime);
            LeftShoulder.transform.Rotate(0f, -.1f, 0f  * Time.deltaTime);
            RightShoulder.transform.Rotate(0f, .1f, 0f * Time.deltaTime);
            LeftThigh.transform.Rotate(0f, -.1f, 0f  * Time.deltaTime);
            RightThigh.transform.Rotate(0f, .1f, 0f  * Time.deltaTime);

        }
    }
}
