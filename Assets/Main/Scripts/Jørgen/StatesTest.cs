using UnityEngine;

[RequireComponent(typeof(CameraShake))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(T_HighScoreSystem))]

public class StatesTest : MonoBehaviour
{
    public Rigidbody rb;
    public bool gameHasStarted;
    public float rotationSpeed = 100;
    public float rotationSpeedMultiplier;
    public float shootingSpeed;
    private Vector3 rotationVector;

    //STATES - when a state is executed, it will only perform the logic within the state.
    private enum States { s_Start, s_Death, s_Flying, s_Rotating, s_DiffRot, }
    private States myState;

    void Start()
    {
        gameHasStarted = false;
        rb = GetComponent<Rigidbody>();
        State_Start();
    }


    private void FixedUpdate()
    {
        ChangeState();
    }

    //##############################################################
    //###-------OnTriggerEnter() Handles all collisions----------###
    //##############################################################

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dead")
        {
            myState = States.s_Death;
            //Play Audio
        }

        /*if (other.tag == "RotationChange" && myState == States.s_Flying)   motsatt rotasjon
        {
            myState = States.s_DiffRot;
        }*/
    }

    //###############################################################
    //###----ChangeState() sends everything to fixedUpdate()------###
    //###############################################################

    void ChangeState()
    {
        print(myState);
        //rb.AddForce(transform.right * shootingSpeed, ForceMode.VelocityChange);
        //Debug.Log(rotationSpeedMultiplier);
        

        if (myState == States.s_Start)                  { State_Start(); }
        else if (myState == States.s_Rotating)          { State_Rotate(); } 
        else if (myState == States.s_Death)             {State_Death(); }
        else if (myState == States.s_Flying)            {State_Flying(); }
        //else if (myState == States.s_DiffRot)           {States_RotationOposite(); }
    }

    //########################################################################################################################################
    //###-----Navigate() tranforms the player forward. Whatever your rotation might be, you will always travel in the correct direction----###
    //########################################################################################################################################

    private void Navigate()
    {
        rb.AddForce(transform.right * shootingSpeed);
        rb.velocity = transform.forward;
    }

    //##################################################
    //###--------------implemented ------------------###
    //##################################################

    private void State_Start()
    {
        rb.isKinematic = true;

        if (Input.GetButton("Fire1"))
        {
            gameHasStarted = true;
            myState = States.s_Rotating;
        }
        
    }

    private void State_Flying()
    {
        Navigate();
        rb.isKinematic = false;
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);

        //TODO adde slider isteden for det pisset her. Origo er nede til venstre, så når du holder musa på midten, så vil den snurre 50% oppover. Slider er fint, for da er
        // rotasjonshastigheten konstant. 
        rotationVector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        rotationSpeed = rotationVector.y *100;


        if (Input.GetKey(KeyCode.W))
        {
            rotationSpeed =  rotationSpeedMultiplier;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rotationSpeed =  rotationSpeedMultiplier;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            myState = States.s_Rotating;
            //Play Audio
        }
    }

    void State_Rotate()
    {
        rb.isKinematic = true;
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);

        if (Input.GetButtonUp("Fire1"))
        {
            myState = States.s_Flying;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetButton("Fire1"))
        {
            rotationSpeed = rotationSpeed + rotationSpeedMultiplier;
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetButton("Fire1"))
        {
            rotationSpeed = rotationSpeed - rotationSpeedMultiplier;
        }
    }

    //######################################################
    //###--------------not implemented ------------------###
    //######################################################

    /*private void States_RotationOposite()
    {
        rb.isKinematic = false;
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
        rb.AddForce(transform.right * shootingSpeed);
        rb.velocity = transform.right;
        if (Input.GetKey(KeyCode.S))
        {
            rotationSpeed = rotationSpeed + rotationSpeedMultiplier;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rotationSpeed = rotationSpeed - rotationSpeedMultiplier;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            myState = States.s_Rotating;
        }
    }*/
    private void State_Death()
    {
    }

    void ResetTimer()
    {

    }
}
