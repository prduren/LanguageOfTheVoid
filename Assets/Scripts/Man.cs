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
    int nextScene;
    GameObject L9Gravity;
    GameObject L9GravityRevert;
    float distanceFromL9Gravity;
    float distanceFromL9GravityRevert;
    bool L9Flag;
    GameObject MansionEntered;
    float distanceFromMansionEntered;
    AudioSource stepsAudioSource;
    AudioSource musicAudioSource;
    bool voidHomeFound = false;
    GameObject PauseCanvas;
    GameObject L9ManTowerCollision;

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
        nextScene = currentScene.buildIndex + 1;
        if (currentSceneName == "L2") {
            L2SceneActiveFlag = true; 
        }
        if (currentSceneName == "L9") {
            L9Flag = true;
            L9Gravity = GameObject.Find("L9Gravity");
            L9GravityRevert = GameObject.Find("L9GravityRevert");
            L9ManTowerCollision = GameObject.Find("ManTowerCollision");
        }
        MansionEntered = GameObject.Find("MansionEntered");
        stepsAudioSource = GameObject.Find("woodStep").GetComponent<AudioSource>();
        musicAudioSource = GameObject.Find("L2Music").GetComponent<AudioSource>();
        stepsAudioSource.mute = ApplicationData.StepsSoundOn;
        musicAudioSource.mute = ApplicationData.MusicSoundOn;
        PauseCanvas = GameObject.Find("PauseCanvas");
    }

    // Update is called once per frame
    void Update()
    {

        distanceFromMansionEntered = Vector3.Distance(Player.transform.position, MansionEntered.transform.position);
        if (distanceFromMansionEntered < 12) {
            RenderSettings.fogEndDistance = 10;
        } else {
            RenderSettings.fogEndDistance = 70;
        }

        if (L9Flag) {
            distanceFromL9Gravity = Vector3.Distance(Player.transform.position, L9Gravity.transform.position);
            distanceFromL9GravityRevert = Vector3.Distance(Player.transform.position, L9GravityRevert.transform.position);

            if (distanceFromL9Gravity < 5) {
                Physics.gravity = new Vector3(0, -60f, 0);
            }

            if (distanceFromL9GravityRevert < 7) {
                Physics.gravity = new Vector3(0, -40f, 0);
                L9ManTowerCollision.GetComponent<SphereCollider>().enabled = true;
            }

        }
        
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
        if (distanceFromVoidHome < 6 && Input.GetMouseButtonDown(0) && PauseCanvas.GetComponent<PauseMenu>().GameIsPaused == false) {
            voidHomeFound = true;
            InitVoidFlag = true;
            Vector3 vec = new Vector3(0, 0, 0);
            Man1.transform.localScale = vec;
            Void.GetComponent<SpriteRenderer>().enabled = true;
            // StartCoroutine(EndingCoroutine());
            // StartCoroutine(AsynchronousLoad(nextScene));
            // use NameFromIndex to pull the name from the next buildIndex scene. wow why is this such an awful workaround
            Initiate.Fade(NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1), Color.black, 0.5f);
        }

        // loop all void homes
        foreach (GameObject home in voidPeopleHomes) {
            distanceFromWrongVoidHome = Vector3.Distance(Man1.transform.position, home.transform.GetChild(0).position);
            if (distanceFromWrongVoidHome < 6 && Input.GetMouseButtonDown(0) && !voidHomeFound && PauseCanvas.GetComponent<PauseMenu>().GameIsPaused == false) {
                endingInit = true;
                StartCoroutine(BadEndingCoroutine());
            }
        }

        if (InitVoidFlag) {
            SpinVoid();
        }


    }

     private static string NameFromIndex(int BuildIndex) {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
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

    IEnumerator AsynchronousLoad (int scene) {
        yield return null;
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;
        while (! ao.isDone) {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            // Loading completed
            if (ao.progress == 0.9f) {
                Debug.Log("Press a key to start");
                if (Input.anyKey)
                    ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}