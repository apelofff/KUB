using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TheUltimateScript : MonoBehaviour {

    //TranstionFade Variabler
    public static TheUltimateScript Instance { get; set; }
    [SerializeField] private Image thisImage;
    private bool isInTranstion;
    private float transtion;
    private bool IsShowing;
    private float duration;
    public static bool startCourtine = false; 

    // Saving variabler
    public static int desiredSave;
    public static int saveInt;
    private Text saveAmount; 

    private void Awake()
    {
         desiredSave = saveInt; 
    }
    // Use this for initialization
    void Start () {
        saveAmount.text = PlayerPrefs.GetInt("SaveInt", saveInt).ToString();
        saveInt = PlayerPrefs.GetInt("SaveInt", saveInt);
	}

    // fade function
    private void Fade(bool showing, float duration)
    {
        IsShowing = showing;
        isInTranstion = true;
        this.duration = duration;
        transtion = (IsShowing) ? 0 : 1;
    }
    // Update is called once per frame
    void Update () {

        
        // fading
        if (!isInTranstion)
            return;

        transtion += (IsShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        thisImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transtion);

        if (transtion > 1 || transtion < 0)
            isInTranstion = false;
    }

    public static void SetSave()
    {
        PlayerPrefs.SetInt("SaveInt", saveInt); 
    }
    

}

