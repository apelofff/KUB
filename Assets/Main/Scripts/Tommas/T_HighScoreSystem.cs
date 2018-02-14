
using UnityEngine;
using UnityEngine.UI;


public class T_HighScoreSystem : MonoBehaviour {

    public Text HighScore;
    public float LocalTime;

    private void Start()
    {

    }

    private void Update()
    {
        LocalTime =+ Time.deltaTime;
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void SettingTheHighSCore()
    {

        Debug.Log(LocalTime);

    }


}
