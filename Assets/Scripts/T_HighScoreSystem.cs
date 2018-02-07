
using UnityEngine;
using UnityEngine.UI;


public class T_HighScoreSystem : MonoBehaviour {

    public Text TimeScore;
    public Text HighScore;
    public float LocalTime; 

    private void Start()
    {

        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    public void SettingTheHighSCore()
    { 


    }


}
