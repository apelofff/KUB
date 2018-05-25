using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TheUltimateScript : MonoBehaviour {

    // Saving variabler
    public static int desiredSave;
    public static int saveInt;
    private Text saveAmount; 

    private void Awake()
    {
         desiredSave = saveInt; 
    }
    // Use this for initialization
    void Start () {
        //saveAmount.text = PlayerPrefs.GetInt("SaveInt", saveInt).ToString();
        saveInt = PlayerPrefs.GetInt("SaveInt", saveInt);
	}

  
    // Update is called once per frame
    void Update () {

        Debug.Log(saveInt); 
     
    }

    public static void SetSave()
    {
        PlayerPrefs.SetInt("SaveInt", saveInt); 
    }
    

}

