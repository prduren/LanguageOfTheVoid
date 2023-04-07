using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    GameObject[] NorthCarsLeft;
    GameObject[] NorthCarsRight;
    GameObject[] SouthCarsLeft;
    GameObject[] SouthCarsRight;
    Vector3 NorthPointLeft;
    Vector3 NorthPointRight;
    Vector3 SouthPointLeft;
    Vector3 SouthPointRight;
    Vector3 CarsNorthResetLeft;
    Vector3 CarsNorthResetRight;
    Vector3 CarsSouthResetLeft;
    Vector3 CarsSouthResetRight;
    float distanceFromNorthLeft;
    float distanceFromNorthRight;
    float distanceFromSouthLeft;
    float distanceFromSouthRight;

    float speed = 5f;

    void Start()
    {
        NorthCarsLeft = GameObject.FindGameObjectsWithTag("CarsNorthLeft");
        SouthCarsLeft = GameObject.FindGameObjectsWithTag("CarsSouthLeft");
        NorthCarsRight = GameObject.FindGameObjectsWithTag("CarsNorthRight");
        SouthCarsRight = GameObject.FindGameObjectsWithTag("CarsSouthRight");
        NorthPointLeft = GameObject.Find("NorthPointLeft").transform.position;
        SouthPointLeft = GameObject.Find("SouthPointLeft").transform.position;
        NorthPointRight = GameObject.Find("NorthPointRight").transform.position;
        SouthPointRight = GameObject.Find("SouthPointRight").transform.position;
        CarsNorthResetLeft = GameObject.Find("CarsNorthResetLeft").transform.position;
        CarsNorthResetRight = GameObject.Find("CarsNorthResetRight").transform.position;
        CarsSouthResetLeft = GameObject.Find("CarsSouthResetLeft").transform.position;
        CarsSouthResetRight = GameObject.Find("CarsSouthResetRight").transform.position;

    }

    void Update()
    {
        var step =  speed * Time.deltaTime;
        foreach (GameObject car in NorthCarsLeft) {
            distanceFromNorthLeft = Vector3.Distance(car.transform.position, NorthPointLeft);
            car.transform.position = Vector3.MoveTowards(car.transform.position, NorthPointLeft, step);
            if (distanceFromNorthLeft < 2) {
                car.transform.position = CarsNorthResetLeft;
            }
        }
        foreach (GameObject car in NorthCarsRight) {
            distanceFromNorthRight = Vector3.Distance(car.transform.position, NorthPointRight);
            car.transform.position = Vector3.MoveTowards(car.transform.position, NorthPointRight, step);
            if (distanceFromNorthRight < 2) {
                car.transform.position = CarsNorthResetRight;
            }
        }
        foreach (GameObject car in SouthCarsLeft) {
            distanceFromSouthLeft = Vector3.Distance(car.transform.position, SouthPointLeft);
            car.transform.position = Vector3.MoveTowards(car.transform.position, SouthPointLeft, step);
            if (distanceFromSouthLeft < 2) {
                car.transform.position = CarsSouthResetLeft;
            }
        }
        foreach (GameObject car in SouthCarsRight) {
            distanceFromSouthRight = Vector3.Distance(car.transform.position, SouthPointRight);
            car.transform.position = Vector3.MoveTowards(car.transform.position, SouthPointRight, step);
            if (distanceFromSouthRight < 2) {
                car.transform.position = CarsSouthResetRight;
            }
        }
    }
}
