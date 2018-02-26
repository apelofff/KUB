using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioPeer : MonoBehaviour {
    public static AudioPeer instance;
    AudioSource _audio;
    public static float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];
	// Use this for initialization


	void Start () {
        _audio = GetComponent<AudioSource>();
        }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
        // Update is called once per frame
        void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
	}

    void GetSpectrumAudioSource()
    {
        _audio.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if ( i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;

            }
            average /= count;
            _freqBand[i] = average * 10;
        }
    }
}
