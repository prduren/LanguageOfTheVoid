using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    GameObject DogTail;

    // Start is called before the first frame update
    void Start()
    {
        DogTail = GameObject.Find("DogTail");
    }

    // Update is called once per frame
    void Update()
    {
        // DogTail.transform.RotateAround(Player.transform.position, Vector3.up, 200f * Time.deltaTime)
        DogTail.transform.rotation = Quaternion.Euler( 30f * Mathf.Sin( Time.time * 2f), 0f, 0f);
    }
}
