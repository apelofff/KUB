using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

//[RequireComponent(typeof(T_HighScoreSystem))]
public class NextLevelManger : MonoBehaviour
{
    public int levelToLoad;
    public Text CurrentLevel; 
    private TheUltimateScript input;

    //public T_HighScoreSystem TimeScore;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            TheUltimateScript.saveInt++;
            TheUltimateScript.SetSave();
            Fade.FadeId = 1;
            Invoke("LoadNextScene",0.1f); 
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
 
}