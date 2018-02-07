using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SlowMotion))]
[RequireComponent(typeof(CameraShake))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(BoxCollider2D))]


public class j_PlayerController : MonoBehaviour {

    [Header("For shooting")]
    public float shootingSpeed;
    private int ID;

    [SerializeField] private Transform ThisTransform;
    [SerializeField] private Rigidbody2D ThisRB = null;
    [SerializeField] private Quaternion newRot = Quaternion.Euler(10f, 0f, 0f);


    [SerializeField] private bool switching = false;

    [Header("Other cube properties")]
    [SerializeField]
    private Vector2 scaleSize;
    [SerializeField] public Vector3 decreasingValue;
    public float rotationSpeedZ = 1f;

    [Header("For Scaling over time")]
    public float scaleDecrease;
    public float timeFloat = 120;

    [Header("Objects outside the game")]
    public GameObject targetArrow;
    public Transform otherPlayer;

    [Header("Juicy")]
    public SlowMotion slowMotion;
    public CameraShake cameraShake;
    private bool ShouldShake;
    public bool isAlive;

    private Vector2 CurrentPos;


    [Header("Players")]
    public GameObject[] gameobjects;

    


    [SerializeField] bool StopMotion = false;



    private enum PlayerStates
    {
        flying, rotating, rotating_otherDirection, dead_fire, dead_electro, dead_collision, dead_projectile,
        dead_color, victory_FirstLevel, victory_SecondLevel, victory_ThirdLevel, victory_Normal,
        victory_Fast, victory_Slow, start, start_tip
    }

    private PlayerStates myState;
    // Use this for initialization
    void Start ()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        ShouldShake = cameraShake.shouldShake;
        myState = PlayerStates.start;
    }


    // Update is called once per frame
    void Update () {
        print(myState);
        if           (myState == PlayerStates.start)                   { start();            }
        else if      (myState == PlayerStates.rotating)                { rotating();         }
        else if      (myState == PlayerStates.flying)                  { flying();           }
        else if      (myState == PlayerStates.dead_collision)          { dead_collision();   }
        else if      (myState == PlayerStates.dead_projectile)         { dead_projectile();  }
        else if      (myState == PlayerStates.dead_electro)            { dead_electro();     }
        else if      (myState == PlayerStates.dead_fire)               { dead_fire();        }
        CurrentPos = transform.position;


        print(ThisRB.velocity);

        timeFloat -= Time.deltaTime;
        if (timeFloat > 0)


        if (Input.GetButton("Jump"))
        {  
            myState = PlayerStates.rotating;
        }

        else if (Input.GetButtonUp("Jump"))
        {
            myState = PlayerStates.flying;
        }
    }

    void start()
    {
        ThisTransform = GetComponent<Transform>();
        ThisRB = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);
        myState = PlayerStates.rotating;
    }

//________________________________________________________________________________________________________________________________________________________________
// Ulike måter å dø på via collisions. UI og lyder må oppdatere for å passe ka vi faktisk kolliderer med. 

    void OnTriggerEnter2D(Collider2D col)
    {
        if      (col.tag == "Normal_Obstacle" && myState == PlayerStates.rotating || myState == PlayerStates.flying)  { myState = PlayerStates.dead_collision;  }

        else if (col.tag == "Projectile" && myState == PlayerStates.rotating || myState == PlayerStates.flying)       { myState = PlayerStates.dead_projectile; }

        else if (col.tag == "fire" && myState == PlayerStates.rotating || myState == PlayerStates.flying)             { myState = PlayerStates.dead_fire;       }

        else if (col.tag == "electro" && myState == PlayerStates.rotating || myState == PlayerStates.flying)          { myState = PlayerStates.dead_electro;    }

    }
    //____________________________________________________________________________________________________________________________________________________________
    // Ulike states. Hva som skjer står inni, men de blir kallet fra FSM. 

    void rotating()
    {
        targetArrow.SetActive(true);
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);
        /*ThisRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;*/
        transform.position = CurrentPos;
    }

    IEnumerator flying()
    {
       
    targetArrow.SetActive(false);
    ThisRB.AddForce(transform.up * shootingSpeed);
    // slowMotion.slowDownActive = true;
    yield return null;
    }

    void dead_collision()
    {
         targetArrow.SetActive(false);

        cameraShake.shouldShake = true;

        Debug.LogWarning("Too tight buddy");

        //Play audio;

        ThisRB.isKinematic = true;

        //Update DeathCounter
        
        //Update UI

        //Play Sound

        if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }

    void dead_projectile()
    {
        ThisRB.isKinematic = true;
        //Update DeathCounter
        Debug.Log("You shot me dooown, but i get uuup");
        //Play audio;
        if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void dead_electro()
    {
        ThisRB.isKinematic = true;
        //Update DeathCounter
        cameraShake.shouldShake = true;
        Debug.Log("Burn baby burn!");
        //Play audio;
        if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void dead_fire()
    {
        ThisRB.isKinematic = true;
        //Update DeathCounter
        cameraShake.shouldShake = true;
        Debug.Log("Burn baby burn!");
        //Play audio;
        if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }





}
