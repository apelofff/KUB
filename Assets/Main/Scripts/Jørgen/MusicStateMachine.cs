using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System.Collections;


public class MusicStateMachine : MonoBehaviour
{
    public AudioSource audio;
    public string[] _clipNames;     //Keep all audio files inside resources folder  and give the value of path alone in this varible through editor.
    int i = 0;

    void Start()
    {
        StartAudio();   // start first time without Delay
    }

    void StartAudio()
    {
        audio.clip = Resources.Load(_clipNames[i]) as AudioClip;
        audio.Play();

        i++;
        if (i >= _clipNames.Length)
            i = 0;
        Invoke("StartAudio", audio.clip.length + 0.5f);    //0.5f is the delay given after a song is over.

    }

}
