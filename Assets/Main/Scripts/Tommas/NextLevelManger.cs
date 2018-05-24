using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(T_HighScoreSystem))]
public class NextLevelManger : MonoBehaviour
{
    public int levelToLoad = 1;
    private TheUltimateScript input; 

    //public T_HighScoreSystem TimeScore;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            TheUltimateScript.saveInt++;
            TheUltimateScript.SetSave();        
        }
    }
}