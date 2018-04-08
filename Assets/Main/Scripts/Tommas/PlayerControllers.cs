using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SlowMotion))]
[RequireComponent(typeof(CameraShake))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(T_HighScoreSystem))]
[RequireComponent(typeof(AudioSource))]



public class PlayerControllers : MonoBehaviour {

    [Header("For shooting")]
    public float shootingSpeed;
    private int ID;

    [SerializeField]private Transform ThisTransform;
    [SerializeField]private Rigidbody ThisRB = null;
    [SerializeField] private Quaternion newRot =  Quaternion.Euler(10f, 0f, 0f);


    [SerializeField]private bool switching = false;

    [Header("Other cube properties")]
    [SerializeField]private Vector3 scaleSize ;
    [SerializeField]public Vector3 decreasingValue;
    public float rotationSpeedZ = 1f;
    public bool RotationOposite = false;
    public float rotationTimer;


    [Header("For Scaling over time")]
    public float scaleDecrease;
    public float timeFloat = 120;

    [Header("Objects outside the game")]
    public GameObject targetArrow;
    private float lerpTime;
    private float shakeDuration;


    [Header("Juicy")]
    public SlowMotion slowMotion;
    public CameraShake cameraShake;
  

    [Header("Players")]
    public GameObject[] gameobjects;


    [SerializeField]
    bool StopMotion = false;
    public bool isDead;
    public T_HighScoreSystem TimeScore;
    public bool nextMapIsStarting;
    public float rotationMultiplier;
    public bool GravitiyisOn = false;
    public NextLevelManger nextLevelManager;


    // proppeling the player foward using rb or the transform
    // the player van press space again to proppel the body forward, then body is kinematic and enable the animation Arrow.
    // the arrow needs to be the foward vector or rigth vector. only needing to rotate the cube.


    // Use this for initialization
    void Start ()
    {
        ThisTransform = GetComponent<Transform>();
        ThisRB = GetComponent<Rigidbody>();
        ThisRB.isKinematic = true;
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);
        lerpTime = Camera.main.GetComponent<CameraShake>().LerpSpeed;
        nextMapIsStarting = false;
        shakeDuration = Camera.main.GetComponent<CameraShake>().intialDuration;
        nextLevelManager = GameObject.Find("NEXTLEVEL").GetComponent<NextLevelManger>();
        


        //slowMotion = GetComponent<SlowMotion>();


    //Invoke("Littlejump", 1f);


}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            rotationSpeedZ = rotationSpeedZ + rotationMultiplier; 
        }
        // This is for the scaling down over time

        timeFloat -= Time.deltaTime;
        rotationTimer -= Time.deltaTime;
       // if (timeFloat>0)
            //scaleSize  = new Vector3(timeFloat / scaleDecrease, timeFloat / scaleDecrease, timeFloat / scaleDecrease);
        //ThisTransform.localScale = scaleSize;

        if (Input.GetButton("Jump") && ID == 1)
        {
            ThisRB.isKinematic = true;

        }
        else if (Input.GetButtonUp("Jump") && StopMotion == true && ID == 1) {
            ThisRB.isKinematic = false; 
            ThisRB.AddForce(transform.right * shootingSpeed);
            FindObjectOfType<AudioManager>().Play("shoot");

        } 
        

        if (Input.GetButtonDown("Jump") && ID == 0 && RotationOposite == false)
        {
            Littlejump();
            RotationOposite = true;
        }
        /*else if (Input.GetButtonDown("Jump") && ID == 0 && RotationOposite == true)
        {
            RotationOposite = false;
        }*/


        if (ThisRB.isKinematic == true && StopMotion == true && ID == 1 && RotationOposite == true)
        {
            targetArrow.SetActive(true);
            transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);
            FindObjectOfType<AudioManager>().Play("rotating");
        } 
        else
            targetArrow.SetActive(false);
        FindObjectOfType<AudioManager>().StopCoroutine("rotating");


        //Metode for å stanse spillet, starte camerashake, og så starte zooming transition
        if (StopMotion == false && ID == 1)
        {
            cameraShake.Shaking(); //Kameraet rister
           // if (Input.GetButton("Jump"))
                //Zoom(); //Kameraet zoomer
        }
    }

   /* private void Zoom()
    {
        cameraShake.Zooming();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<AudioManager>().Play("nextMap");
        StopAllCoroutines();
    }*/


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            float add = other.transform.localScale.x * scaleDecrease;
            timeFloat = Mathf.Sqrt(timeFloat * timeFloat + add * add);
            ThisTransform.transform.position = other.transform.position;
            DestroyObject(other.gameObject);     
        }
       

        //________________________________________________________________________________________________________________________

        if(other.tag == "Dead")
        {
            TimeScore.OnDeath();
            cameraShake.shouldShake = true;
            StopMotion = false; 
            ThisRB.isKinematic = true;
            FindObjectOfType<AudioManager>().Play("normalObstacle");
        }

        if(other.tag == "RotationChange" && RotationOposite == false)
        {
            rotationTimer = 10;
            RotationOposite = true;
        }

        /*if (other.tag == "NEXTLEVEL")
        {
            StartCoroutine(nextLevelManager.Transition());
        }*/

        //_____________MUSIC________________

        if (other.tag == "Sound2")
        {
            Sound2 = true;
        }
    }

    void ChangeRotation()
    {
        if (rotationTimer == 0)
        {
            RotationOposite = false;
        }
    }

    void Littlejump()
    {
     
        ThisRB.AddForce(transform.up * shootingSpeed);
        StopMotion = true;
        
        // slowMotion.slowDownActive = true; 

        ID = 1;


  
    }
    public bool Sound2 = false;

   




}
