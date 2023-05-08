using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseM1 : MonoBehaviour
{

    public GameObject M1Click;
    public GameObject DownM1;
    public GameObject UpM1;
    bool movingDown;
    float distanceFromDownM1;
    float distanceFromUpM1;

    // Start is called before the first frame update
    void Start()
    {
        movingDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromDownM1 = Vector3.Distance(M1Click.transform.position, DownM1.transform.position);
        distanceFromUpM1 = Vector3.Distance(M1Click.transform.position, UpM1.transform.position);

        if (movingDown) {
            // MoveTowards DownM1
            M1Click.transform.position = Vector3.MoveTowards(M1Click.transform.position, DownM1.transform.position, 2f * Time.deltaTime);
            if (distanceFromDownM1 < .1f) {
                movingDown = false;
            }
        } else {
            // MoveTowards Up1
            M1Click.transform.position = Vector3.MoveTowards(M1Click.transform.position, UpM1.transform.position, 2f * Time.deltaTime);
            if (distanceFromUpM1 < .1f) {
                movingDown = true;
            }
        }
        
    }
}
