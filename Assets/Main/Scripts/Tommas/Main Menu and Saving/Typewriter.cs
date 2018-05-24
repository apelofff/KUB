using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    public float speed;
    public Text textField;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip nlClip;

    private string textValue;
    private float typeTime;
    private int index;
    private float time;

    // Use this for initialization
    void Start()
    {
        textValue = textField.text;
        textField.text = "";
         
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time; 
        if (time >= 3f)
        {
            if (index < textValue.Length)
            {
                if (typeTime >= 1)
                {
                    typeTime = 0;
                    char character = textValue[index];
                    textField.text += character;
                    AudioClip clipToPlay = clip;
                    if (character == '.')
                    {
                        audioSource.pitch = 0.8f;
                    }
                    else if (character == '\n' || character == '\r')
                    {
                        clipToPlay = nlClip;
                        typeTime = -3;
                    }
                    else if (character != ' ')
                    {
                        audioSource.pitch = Random.Range(1, 1);
                    }
                    else
                    {
                        typeTime = -1;
                    }
                    audioSource.PlayOneShot(clipToPlay);
                    index++;
                }
                else
                {
                    typeTime += Time.deltaTime * speed;
                }
            }
        }
    }
}
