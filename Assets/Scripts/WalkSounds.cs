using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSounds : MonoBehaviour
{
    
    GameObject Player;
    GameObject woodFloor;
    GameObject concreteFloor;
    AudioSource woodSoundSource;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        woodSoundSource = GameObject.Find("woodStep").GetComponent<AudioSource>();
        woodSoundSource.pitch = 2f;
        // Floor objects
            woodFloor = GameObject.FindGameObjectWithTag("woodFloor");
    }

    void Update() {
        if  (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) {
            if (!woodSoundSource.isPlaying) {
                woodSoundSource.Play();
            }
        }
        else {
            woodSoundSource.Stop();
        }

        // this stuff below is for if you need to actually loop an array of each woodFloor with the woodFloor tag

        // foreach (GameObject i in woodFloor) {
            // if you're pretty much only on top of the thing
            // if  (((Player.transform.position.x - i.transform.position.x) < 5) & 
                // ((Player.transform.position.z - i.transform.position.z) < 5) &
                //((Player.transform.position.x - i.transform.position.x) > -5) & 
                // ((Player.transform.position.z - i.transform.position.z) > -5)) {
                    //woodSoundSource.PlayOneShot(woodSoundSource.clip);
                   // woodSoundSource.Play();
            // }
        //}
    }
}
