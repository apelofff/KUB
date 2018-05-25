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

    // Use this for initialization
    void Awake () {
        Instance = this; 
	}

    // fade function
    private void Fades(bool showing, float duration)
    {
        IsShowing = showing;
        isInTranstion = true;
        this.duration = duration;
        transtion = (IsShowing) ? 0 : 1;
    }
    // Update is called once per frame
    void Update () {
        // fading
        if (Input.GetKeyDown(KeyCode.B))
        {
            Fades(true, 1.00f);

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Fades(false, 3.5f);
        }

        if (!isInTranstion)
            return;

        transtion += (IsShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        thisImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transtion);

        if (transtion > 1 || transtion < 0)
            isInTranstion = false;

    
    }
}
