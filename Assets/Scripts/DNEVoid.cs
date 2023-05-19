using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DNEVoid : MonoBehaviour
{

    private float rotationRate;
    float distanceFromDNETeleporter;
    GameObject DNETeleporter;
    GameObject Player;
    GameObject[] DNEZonePeople;
    //IDictionary<int, Vector3> peopleOriginalPos = new Dictionary<int, Vector3>();
    //int peopleIndex = 0;
    string currentSceneName;

    void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        rotationRate = 8f;
        DNETeleporter = GameObject.Find("DNETeleporter");
        Player = GameObject.Find("Player");
        DNEZonePeople = GameObject.FindGameObjectsWithTag("DNEZonePeople");
        foreach(GameObject p in DNEZonePeople) {
            // peopleIndex ++;
            // peopleOriginalPos.Add(peopleIndex, p.transform.position);
        }
        /* foreach(KeyValuePair<int, Vector3> kvp in peopleOriginalPos) {
            Debug.Log("Key: {0}, Value: {1}" + kvp.Key + kvp.Value);
        } */
    }

    void Update()
    {
        distanceFromDNETeleporter = Vector3.Distance(Player.transform.position, DNETeleporter.transform.position);
        if (distanceFromDNETeleporter < 1) {
            if (currentSceneName == "DNEZone") {
                Initiate.Fade(ReturnPreviousLevel.PreviousLevel, Color.black, 0.5f);
            } else {
                Initiate.Fade("DNEZone", Color.black, 0.5f);
            }
        }
        foreach(GameObject p in DNEZonePeople) {
            if (p.transform.position.y < -30) {
                p.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 100, p.transform.position.z);
            }
        }
        transform.Rotate(0f, 0f, 6.0f * rotationRate * Time.deltaTime);
    }
}
