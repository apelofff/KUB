using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SlowMotion))]
[RequireComponent(typeof(CameraShake))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]



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
    public bool rotatateDirection;

    [Header("For Scaling over time")]
    public float scaleDecrease;
    public float timeFloat = 120;

    [Header("Objects outside the game")]
    public GameObject targetArrow;
    public Transform otherPlayer; 

    [Header("Juicy")]
    public SlowMotion slowMotion;
    public CameraShake cameraShake;
  

    [Header("Players")]
    public GameObject[] gameobjects;


    [SerializeField] bool StopMotion = false;

    
    // proppeling the player foward using rb or the transform
    // the player van press space again to proppel the body forward, then body is kinematic and enable the animation Arrow.
    // the arrow needs to be the foward vector or rigth vector. only needing to rotate the cube.
    

	// Use this for initialization
	void Start () {
        rotatateDirection = true;
        ThisTransform = GetComponent<Transform>();
        ThisRB = GetComponent<Rigidbody>();
        ThisRB.isKinematic = true;
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);


        //slowMotion = GetComponent<SlowMotion>();


        //Invoke("Littlejump", 1f);


    }
	
	// Update is called once per frame
	void Update () {

        // This is for the scaling down over time

        timeFloat -= Time.deltaTime;
        if(timeFloat>0)
            scaleSize  = new Vector3(timeFloat / scaleDecrease, timeFloat / scaleDecrease, timeFloat / scaleDecrease);
        ThisTransform.localScale = scaleSize ;
        if (Input.GetButton("Jump") && ID == 1)
        {
            ThisRB.isKinematic = true;

        }
        else if (Input.GetButtonUp("Jump") && StopMotion == true && ID == 1 && rotatateDirection == true) {
            ThisRB.isKinematic = false; 
            ThisRB.AddForce(transform.right * shootingSpeed);
            rotatateDirection = false;
        }

        else if (Input.GetButtonUp("Jump") && StopMotion == true && ID == 1 && rotatateDirection == false)
        {
            ThisRB.isKinematic = false;
            ThisRB.AddForce(transform.right * shootingSpeed);
            rotatateDirection = true;
        }

        if (Input.GetButtonDown("Jump") && ID == 0)
        {
            Littlejump();
        }
        //_____________________________________________________________


        // SlowMotion state, and aiming state
        if (ThisRB.isKinematic == true && StopMotion == true && ID == 1 && rotatateDirection == true)
        {
            targetArrow.SetActive(true);
            transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);
        }

        else if (ThisRB.isKinematic == true && StopMotion == true && ID == 1 && rotatateDirection == false)
        {
            targetArrow.SetActive(true);
            transform.Rotate(0, 0, Time.deltaTime * -rotationSpeedZ);
        }

        else
            targetArrow.SetActive(false);

        if (Input.GetButtonDown("Jump") && StopMotion == false && ID == 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
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
            cameraShake.shouldShake = true;
            StopMotion = false; 
            ThisRB.isKinematic = true;

        }
    }

    void Littlejump()
    {
     
        ThisRB.AddForce(transform.up * shootingSpeed);
        StopMotion = true;
        // slowMotion.slowDownActive = true; 

        ID = 1;

    }

}
