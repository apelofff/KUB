using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(T_HighScoreSystem))]
public class NextLevelManger : MonoBehaviour
{
    public int levelToLoad;

    private TheUltimateScript input;

    //public T_HighScoreSystem TimeScore;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            TheUltimateScript.saveInt++;
            TheUltimateScript.SetSave();
            Fade.FadeId = 1;
            Invoke("LoadNextScene", 1f); 
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}