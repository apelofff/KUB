using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SlowMotion))]
[RequireComponent(typeof(CameraShake))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(T_HighScoreSystem))]



public class StatesTest : MonoBehaviour
{
    private enum States { s_Death, s_Flying, s_Rotating, s_DiffRot, }
    private States myState;
    [Header("For shooting")]
    public float shootingSpeed;

    private Transform ThisTransform;
    private Rigidbody ThisRB = null;
    private Quaternion newRot = Quaternion.Euler(10f, 0f, 0f);

    [Header("Other cube properties")]
    private Vector3 scaleSize;
    public float rotationSpeedZ = 1f;
    public bool RotationOposite = false;
    public float rotationTimer;


    [Header("For Scaling over time")]
    public float scaleDecrease;
    public float timeFloat = 120;

    [Header("Objects outside the game")]
    public GameObject targetArrow;


    [Header("Juicy")]
    public SlowMotion slowMotion;
    public CameraShake cameraShake;


    [Header("Players")]
    public GameObject[] gameobjects;


    [SerializeField] bool StopMotion = false;
    public T_HighScoreSystem TimeScore;


    // proppeling the player foward using rb or the transform
    // the player van press space again to proppel the body forward, then body is kinematic and enable the animation Arrow.
    // the arrow needs to be the foward vector or rigth vector. only needing to rotate the cube.


    // Use this for initialization
    void Start()
    {
        myState = States.s_Rotating;

        ThisTransform = GetComponent<Transform>();
        ThisRB = GetComponent<Rigidbody>();
        ThisRB.isKinematic = true;
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);
        TimeScore = GetComponent<T_HighScoreSystem>();
        
        //slowMotion = GetComponent<SlowMotion>();
        //Invoke("Littlejump", 1f);
    }
    // Update is called once per frame
    void Update()
    {
        print(myState);

        ResetTimer();

        if (myState == States.s_Rotating)       { State_Rotate();}
        else if (myState == States.s_Death)     {State_Death();}
        else if(myState == States.s_Flying)     {State_Flying();}
        else if(myState == States.s_DiffRot)    {States_RotationOposite();}

        // This is for the scaling down over time

        timeFloat -= Time.deltaTime;
        rotationTimer -= Time.deltaTime;
        /*if (timeFloat > 0)
            scaleSize = new Vector3(timeFloat / scaleDecrease, timeFloat / scaleDecrease, timeFloat / scaleDecrease);
        ThisTransform.localScale = scaleSize;*/

        if (Input.GetButton("Jump"))
        {
            State_Rotate();

        }
        else if (Input.GetButtonUp("Jump") && StopMotion == true)
        {
            ThisRB.isKinematic = false;
            ThisRB.AddForce(transform.right * shootingSpeed);
            State_Flying();
        }

        else if (Input.GetButtonDown("Jump") && RotationOposite == true)
        {
            States_RotationOposite();
        }

        if (Input.GetButtonDown("Jump") && StopMotion == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void State_Flying()
    {
        ThisRB.isKinematic = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player") //If colliding with a object that adds scale
        {
            float add = other.transform.localScale.x * scaleDecrease;
            /*timeFloat = Mathf.Sqrt(timeFloat * timeFloat + add * add);*/

            ThisTransform.transform.position = other.transform.position;
            DestroyObject(other.gameObject);
            //Play audio (Blob Sound?)
        }

        if (other.tag == "RotationChange" && RotationOposite == false) //changes rotation
        {
            States_RotationOposite();
        }

        if (other.tag == "Dead") //any Obstacle that kills you
        {
            State_Death();
        }
    }

    private void States_RotationOposite()
    {
        rotationTimer = 10;
        RotationOposite = true;

        if (ThisRB.isKinematic == true && StopMotion == true && RotationOposite == true)
        {
            targetArrow.SetActive(true);
            transform.Rotate(0, 0, Time.deltaTime * -rotationSpeedZ);
            //Play Audio(rotation audio backwards?)
        }
        else
            targetArrow.SetActive(false);
    }

    void Littlejump()
    {
        ThisRB.AddForce(transform.up * shootingSpeed);
        StopMotion = true;
        // slowMotion.slowDownActive = true; 
    }

    void State_Rotate()
    {
        if (StopMotion == true && RotationOposite == false)
        {
            ThisRB.isKinematic = true;
            targetArrow.SetActive(true);
            transform.Rotate(0, 0, Time.deltaTime * rotationSpeedZ);
            //Play Audio
        }
        else
            targetArrow.SetActive(false);
    }

    private void State_Death()
    {
        TimeScore.OnDeath();
        cameraShake.shouldShake = true;
        StopMotion = false;
        ThisRB.isKinematic = true;
        //PlayAudio
    }

    void ResetTimer()
    {
        if (rotationTimer < 0)
        {
            RotationOposite = false;
        }
    }
}
