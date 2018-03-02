using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Beat {
    public string beatname;
    public AudioClip beatclip;

    [Range(0.1f, 3f)]
    public float beatpitch;

    [Range(0f, 1f)]
    public float beatvolume;
}
