using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFile : MonoBehaviour {

    public static int HighestUnlockedLevel = 1; 

    public  GameObject[] LevelLoadButtons;
    private int index;
    

    // make a dont destroy manger script that runns thrueout the whole game, that also stores data 
    // Get the data when when you load the scene in awake function set desierd = to stored data 

    private void Start()
    {
        index = TheUltimateScript.desiredSave; 
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        SceneManager.LoadScene(index);
    }
  

    


}
