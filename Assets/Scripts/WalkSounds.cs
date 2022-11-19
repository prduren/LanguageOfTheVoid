using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSounds : MonoBehaviour
{
    
    GameObject Player;
    GameObject[] woodFloor;
    GameObject concreteFloor;
    AudioSource woodSoundSource;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        woodSoundSource = GameObject.Find("woodStep").GetComponent<AudioSource>();
        // Floor objects
            woodFloor = GameObject.FindGameObjectsWithTag("woodFloor");
    }

    void Update()
    {
        foreach (GameObject i in woodFloor) {
            // if you're pretty much only on top of the thing
            if  (((Player.transform.position.x - i.transform.position.x) < 1) & 
                ((Player.transform.position.z - i.transform.position.z) < 1) &
                ((Player.transform.position.x - i.transform.position.x) > -1) & 
                ((Player.transform.position.z - i.transform.position.z) > -1)) {
                    //woodSoundSource.PlayOneShot(woodSoundSource.clip);
                    woodSoundSource.Play();
            }
        }
    }
}
