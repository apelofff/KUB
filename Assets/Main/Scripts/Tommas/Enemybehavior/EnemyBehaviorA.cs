using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class EnemyBehaviorA : MonoBehaviour
{

    [SerializeField] private Transform PlayerTarget;
    private Vector3 orginalPosition;
=======
public class EnemyBehavior : MonoBehaviour {

    [SerializeField]private Transform PlayerTarget;
    private Vector3 orginalPosition; 
>>>>>>> 889947a8acc74e019157904238283f5a64d0279e
    public static bool ISTargetInRange;

    public Renderer makeEnemyRed;
    [SerializeField] private Material[] materialForEnemy;

<<<<<<< HEAD
    [Range(0.01f, 15.0f)]
    public float EnemySpeed;
    private bool forCreatingState;


    void Start()
    {
=======
    [Range(0.01f,0.1f)]
    public float EnemySpeed;
    private bool forCreatingState;
     

    void Start () {
>>>>>>> 889947a8acc74e019157904238283f5a64d0279e

        orginalPosition = transform.position;
        makeEnemyRed = GetComponent<Renderer>();
        makeEnemyRed.enabled = true;
<<<<<<< HEAD

=======
      
>>>>>>> 889947a8acc74e019157904238283f5a64d0279e
        makeEnemyRed.sharedMaterial = materialForEnemy[0];
    }

    void Update()
    {
<<<<<<< HEAD
        if (transform.position == orginalPosition)
        {

            forCreatingState = false;

        }


        if (ISTargetInRange == true)
        {

            makeEnemyRed.sharedMaterial = materialForEnemy[1];
            transform.LookAt(PlayerTarget);
            AttackMode();

        }

        if (forCreatingState == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, orginalPosition, EnemySpeed * Time.deltaTime);
        }
    }
    void AttackMode()
    {
        Debug.Log("I am attacking");

        if (forCreatingState == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.transform.position, EnemySpeed * Time.deltaTime);
        }
        else if (forCreatingState == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, orginalPosition, EnemySpeed * Time.deltaTime);
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Dead")
        {
=======
        if (transform.position == orginalPosition ){

            forCreatingState = false;
             
        }
            

        if (ISTargetInRange == true)
        {

            makeEnemyRed.sharedMaterial = materialForEnemy[1];
            transform.LookAt(PlayerTarget);
            AttackMode();

        }

        if (forCreatingState == true )
        {
            transform.position = Vector3.MoveTowards(transform.position, orginalPosition, EnemySpeed);
        }
    }
    void AttackMode(){
        Debug.Log("I am attacking");

        if (forCreatingState == false){
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.transform.position, EnemySpeed);
        } else if (forCreatingState == true) {
            transform.position = Vector3.MoveTowards(transform.position, orginalPosition, EnemySpeed);
        }
    }

    private void OnTriggerEnter(Collider other){

        if(other.tag == "Dead"){
>>>>>>> 889947a8acc74e019157904238283f5a64d0279e
            forCreatingState = true;
            ISTargetInRange = false;
            makeEnemyRed.sharedMaterial = materialForEnemy[0];
        }
    }
<<<<<<< HEAD
    */

}
=======


}
>>>>>>> 889947a8acc74e019157904238283f5a64d0279e
