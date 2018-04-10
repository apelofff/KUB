using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUps : MonoBehaviour {

    private bool Death = false;

    public static int[][] pickup = new int[5][]
    {
      /* Stage 1*/ new int[]  {2,1,2,3,4},
      /* Stage 2*/ new int[] {3,6,7},
      /* Stage 3*/ new int[] {4,9},
      /* Stage 4*/ new int[] {5,11},
      /* Stage 5*/ new int[] {5, 89}
    };

    public static int Stage;
    public static int Level;
    public static int coreChangeValueInStage;
    public static int AtthisLevel;
    public static bool IsThisANormalLevel = false;
    public static int pickupcounter;

    // Use this for initialization
    void Start () {
        Stage = 3;
        Level = 1;
        coreChangeValueInStage = 3;
        AtthisLevel = 1;
        Debug.Log(pickup[Stage][Level]);
        pickupcounter = pickup[Stage][Level];
        
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(pickupcounter);

        if (Input.GetKeyDown(KeyCode.L)){
            IsThisANormalLevel = true;
            Debug.Log("Heyoo"); 
        }

        if(IsThisANormalLevel == false){
            if (Input.GetKeyDown(KeyCode.Space)){
                pickupcounter = pickupcounter - 1;
            }
            if (pickupcounter == 0) {
                Death = true;              
            }            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickups"){
            pickupcounter++;  
        }
    }

    private void OnDestroy()
    {
       if(Death == true){
            Debug.Log("You are dead :(");
        }
    }
}
