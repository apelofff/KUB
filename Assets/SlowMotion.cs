
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public bool slowDownActive;
    private float slowDownTimer;


    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;

    public void Update()
    {
        slowDownTimer += (slowDownActive ? Time.deltaTime : -Time.deltaTime) / slowDownLength;
        slowDownTimer = Mathf.Clamp01(slowDownTimer);

        Time.timeScale = Mathf.Lerp(1, slowDownFactor, slowDownTimer);
    }
}
