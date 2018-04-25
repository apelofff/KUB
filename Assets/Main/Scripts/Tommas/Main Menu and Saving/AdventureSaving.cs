using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureSaving : MonoBehaviour {

    private void Start()
    {
        SaveFile.HighestUnlockedLevel = PlayerPrefs.GetInt("LevelSave", SaveFile.HighestUnlockedLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("This Should save MAybe");
            SaveFile.HighestUnlockedLevel++;
            PlayerPrefs.SetInt("LevelSave", SaveFile.HighestUnlockedLevel);
        }
    }

}
