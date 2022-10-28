using UnityEngine;

public class doorScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.Find("doorRight").transform.position);
    }
}
