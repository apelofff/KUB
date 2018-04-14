using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFile : MonoBehaviour {

    public static int HighestUnlockedLevel = 1; 

    public  GameObject[] LevelLoadButtons;
    private int ArrayofLevels; 
    
    void Update () {

        Debug.Log(HighestUnlockedLevel);
        for (int i = HighestUnlockedLevel + 1; i<LevelLoadButtons.Length; i++)
        {
           
            LevelLoadButtons[i].SetActive(false); 
        }
    }
    void LevelSelect(int index)
    {
        if (HighestUnlockedLevel == index)
        {
            SceneManager.LoadScene(index);
        }
    }
    void UnlockedLevels()
    {
        
        ArrayofLevels = HighestUnlockedLevel - 1;
        LevelLoadButtons[ArrayofLevels].SetActive(false);
        
    }

    


}
