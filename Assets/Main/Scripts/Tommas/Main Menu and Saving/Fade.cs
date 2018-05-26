using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    //TranstionFade Variabler
    public static Fade Instance { get; set; }
    [SerializeField] private Image thisImage;
    private bool isInTranstion;
    private float transtion;
    private bool IsShowing;
    private float duration;
    public static bool startCourtine = false;
    public static  int FadeId = 0; 

    // Use this for initialization
    void Awake () {
        Instance = this; 
	}
    private void Start()
    {
        Fades(false, 0.5f); 
    }
    // fade function
    private void Fades(bool showing, float duration)
    {
        IsShowing = showing;
        isInTranstion = true;
        this.duration = duration;
        transtion = (IsShowing) ? 0 : 1;
    }
    IEnumerator FadeInNewLevel()
    {
        yield return new WaitForSeconds(1f);
        Fades(false, 0.5f);
            
    }
    // Update is called once per frame
    void Update () {
        // fading
        if (Input.GetKeyDown(KeyCode.B))
            FadeId = 1; 

        if (FadeId == 1)
        {
            Fades(true, 0.1f);
            FadeId = 2; 
        }
        else if (FadeId == 2)
        {

            StartCoroutine(FadeInNewLevel());
            StopCoroutine(FadeInNewLevel());
            FadeId = 0;
        }
       

        if (!isInTranstion)
            return;

        transtion += (IsShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        thisImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transtion);

        if (transtion > 1 || transtion < 0)
            isInTranstion = false;

    
    }
    
}
