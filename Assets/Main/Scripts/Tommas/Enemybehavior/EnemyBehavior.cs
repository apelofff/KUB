using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] private Transform PlayerTarget;
    private Vector3 orginalPosition;
    public static bool ISTargetInRange;

    public Renderer makeEnemyRed;
    [SerializeField] private Material[] materialForEnemy;

    [Range(0.01f, 15.0f)]
    public float EnemySpeed;
    private bool forCreatingState;


    void Start()
    {

        orginalPosition = transform.position;
        makeEnemyRed = GetComponent<Renderer>();
        makeEnemyRed.enabled = true;

        makeEnemyRed.sharedMaterial = materialForEnemy[0];
    }

    void Update()
    {
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
            forCreatingState = true;
            ISTargetInRange = false;
            makeEnemyRed.sharedMaterial = materialForEnemy[0];
        }
    }
    */

}