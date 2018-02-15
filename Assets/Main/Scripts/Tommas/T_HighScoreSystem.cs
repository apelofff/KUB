
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

  
    private void Start()
    {

        Highscore.text = PlayerPrefs.GetFloat("Highscore", 1).ToString();
        Deathcounter.text = PlayerPrefs.GetInt("Deathcounter",deathAmount).ToString();
        deathAmount = PlayerPrefs.GetInt("Deathcounter", deathAmount);
    
    }
    
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {    


            deathAmount++;
        }
        if (deathAmount > PlayerPrefs.GetInt("Deathcounter",deathAmount))
        {
            Deathcounter.text = deathAmount.ToString();
            PlayerPrefs.SetInt("Deathcounter", deathAmount);
            
        }

       
        if (IsTimerOn == true)
        {
            currentTimeOnThisLevel = Time.time;
            currentTimeOnThisLevel = Mathf.Round(currentTimeOnThisLevel);
            text.text = currentTimeOnThisLevel.ToString();

            if (currentTimeOnThisLevel > PlayerPrefs.GetFloat("Highscore", 1))
            {
                PlayerPrefs.SetFloat("Highscore", currentTimeOnThisLevel);
                Highscore.text = currentTimeOnThisLevel.ToString();
            }
        }
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


