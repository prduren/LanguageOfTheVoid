using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Man : MonoBehaviour
{

    private float timeBetweenDoingSomething = 5f;  // Wait 5 seconds after we do something to do something again
    private float timeWhenWeNextDoSomething;  // The next time we do something
    bool endingInit;
    public Material material1;
    public Material material2;
    public Renderer rend;
    GameObject[] endingPeople;
    GameObject[] voidPeopleHomes;
    GameObject Player;
    GameObject Man1;
    GameObject Man1Parent;
    GameObject VoidHome;
    GameObject Void;
    Vector3 originalPos;
    Vector3 PlayerInitPos;
    Vector3 Man1ParentInitPos;
    float distanceFromVoidHome;
    float distanceFromWrongVoidHome;
    float playerDistanceFromMan;
    bool manAttached = false;
    float voidRotationsPerMinute = 200.0f;
    bool InitVoidFlag = false;
    bool L2SceneActiveFlag = false;
    string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
        endingInit = false;
        endingPeople = GameObject.FindGameObjectsWithTag("endingPeople");
        voidPeopleHomes = GameObject.FindGameObjectsWithTag("voidPeopleHomes");
        rend.material = material1;
        Player = GameObject.Find("Player");
        PlayerInitPos = Player.transform.position;
        Man1 = GameObject.Find("man1");
        originalPos = new Vector3(26, 0, -5);
        Man1Parent = GameObject.Find("man1Parent");
        Man1ParentInitPos = Man1Parent.transform.position;
        VoidHome = GameObject.Find("VoidHome");
        Void = GameObject.Find("void");
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        if (currentSceneName == "L2") {
            L2SceneActiveFlag = true; 
        }
        foreach (GameObject person in endingPeople) {

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (endingInit) {
            SpinEndingMen();
            foreach (GameObject person in endingPeople) {
                // person.transform.localScale += (new Vector3(1f, 5f, 1f) * Time.deltaTime);
                person.transform.localScale = Vector3.Lerp(person.transform.localScale, person.transform.localScale * 1.3f, Time.deltaTime * 2);
            }
        }

        //Spin man for L2
        if (L2SceneActiveFlag) {
            Man1.transform.Rotate(0, 0, .25f);
        }

        distanceFromVoidHome = Vector3.Distance(Man1.transform.position, VoidHome.transform.position);
        playerDistanceFromMan = Vector3.Distance(Man1.transform.position, Player.transform.position);
        
        // grab the man if Player is close enough
        if ((Input.GetKeyDown(KeyCode.V)) & (playerDistanceFromMan < 3)) {
            manAttached = true;
        }

        // if grabbing man
        if (manAttached) {
            Man1Parent.transform.SetParent(Player.transform);
            Man1Parent.transform.RotateAround(Player.transform.position, Vector3.up, 200f * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.C)) {
                manAttached = false;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // this assumes the mouse is at the center of the screen
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
                    {
                        Vector3 P = x * Vector3.Normalize(B - A) + A;
                        return P;
                    }
                    Man1.transform.position = LerpByDistance(Player.transform.position, Man1.transform.position, 2f);
                    Man1Parent.transform.SetParent(null);
                }
            }
        // if not grabbing man / if let go of man
        }
        else if (!manAttached) {
                // nothing
        }

        // if man is close enough to correct void home then end level
        if (distanceFromVoidHome < 3 && Input.GetMouseButtonDown(0)) {
            InitVoidFlag = true;
            Vector3 vec = new Vector3(0, 0, 0);
            Man1.transform.localScale = vec;
            Void.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(EndingCoroutine());
        }

        // loop all void homes, 
        // TODO: apply to all levels (add tags to void homes)
        foreach (GameObject home in voidPeopleHomes) {
            distanceFromWrongVoidHome = Vector3.Distance(Man1.transform.position, home.transform.GetChild(0).position);
            if (distanceFromWrongVoidHome < 3 && Input.GetMouseButtonDown(0)) {
                endingInit = true;
                StartCoroutine(BadEndingCoroutine());
            }
        }

        if (InitVoidFlag) {
            SpinVoid();
        }


    }


    void SpinEndingMen() {
        foreach (GameObject person in endingPeople) {
           person.transform.Find("Small Man").gameObject.SetActive(true);
           person.transform.RotateAround(Player.transform.position, Vector3.up, (Mathf.Lerp(5f, 1000f, 100f) * Time.deltaTime));
        }
        if (endingInit) {
           foreach (GameObject person in endingPeople) {
              person.transform.localScale = Vector3.Lerp(person.transform.localScale, person.transform.localScale * 1.3f, Time.deltaTime * 2);
           }
       }
    }

    void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void SpinVoid() {
        Void.transform.Rotate(0f, 0f, 6.0f * voidRotationsPerMinute * Time.deltaTime);
    }

    IEnumerator EndingCoroutine() {
        yield return new WaitForSeconds(5);
        LoadNextScene();
    }

    IEnumerator BadEndingCoroutine() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Player.transform.position = PlayerInitPos;
        // manAttached = false;
        // Man1Parent.transform.position = Man1ParentInitPos;
        // Man1Parent.transform.SetParent(null);
    }

}