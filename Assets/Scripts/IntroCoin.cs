using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCoin : MonoBehaviour
{

    GameObject IntroductionCoin;

    // Start is called before the first frame update
    void Start()
    {
        IntroductionCoin = GameObject.Find("IntroCoin");
        StartCoroutine(WaitAndNextScene());
    }

    // Update is called once per frame
    void Update()
    {
        IntroductionCoin.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 180f);
    }

    IEnumerator WaitAndNextScene() {
        yield return new WaitForSeconds(3);
        Initiate.Fade("Intro", Color.black, 3f);
    }

}
