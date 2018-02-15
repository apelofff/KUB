
using UnityEngine;
using UnityEngine.UI;


public class T_HighScoreSystem : MonoBehaviour {

    [SerializeField] private float currentTimeOnThisLevel = 1 ;
 

    public bool IsTimerOn; 

    public Text text;
    public Text Highscore;


    private void Start()
    {
        Highscore.text = PlayerPrefs.GetFloat("Highscore", 1).ToString();   
    }
    
    void Update()
    {
        
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
}


