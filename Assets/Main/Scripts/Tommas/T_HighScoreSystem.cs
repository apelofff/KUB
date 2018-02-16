﻿
using UnityEngine;
using UnityEngine.UI;


public class T_HighScoreSystem : MonoBehaviour {

    [SerializeField] private float currentTimeOnThisLevel = 1 ;


    public int deathAmount;
    public bool IsTimerOn;
    public GameObject GameOverText;
    public Text text;
    public Text Highscore;
    public Text Deathcounter;
    public bool DevResetNBThisWillResetAll;
    public float controlingTime = 1f;

  
    private void Start()
    {

        Highscore.text = PlayerPrefs.GetFloat("Highscore").ToString();
        Deathcounter.text = PlayerPrefs.GetInt("Deathcounter",deathAmount).ToString();
        deathAmount = PlayerPrefs.GetInt("Deathcounter", deathAmount);
        currentTimeOnThisLevel = 0;

    }
    
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {    
            deathAmount++;
        }
        if (deathAmount >= PlayerPrefs.GetInt("Deathcounter",deathAmount))
        {
            Deathcounter.text = deathAmount.ToString();
            PlayerPrefs.SetInt("Deathcounter", deathAmount);
            
        }

       

        if (IsTimerOn == true)
        {
            currentTimeOnThisLevel += Time.deltaTime; 
           float RoundedTimeOnThisLevel = Mathf.Round(currentTimeOnThisLevel);
            text.text = RoundedTimeOnThisLevel.ToString();

        }
    }

    public void SetHighScore()
    {
        IsTimerOn = false;
        float RoundedTimeOnThisLevel = Mathf.Round(currentTimeOnThisLevel);

        if (RoundedTimeOnThisLevel <= PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", RoundedTimeOnThisLevel);
            Highscore.text = RoundedTimeOnThisLevel.ToString();
        }
 
         currentTimeOnThisLevel = 0;

    }

    public void Reset()
    {
        if(DevResetNBThisWillResetAll == true)
        {
            PlayerPrefs.DeleteAll();
            //Highscore.ToString;
        }
    }
}


