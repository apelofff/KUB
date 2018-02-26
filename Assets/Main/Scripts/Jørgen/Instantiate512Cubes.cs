using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 512; i++)
        {
            GameObject _instantSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instantSampleCube.transform.position = this.transform.position;
            _instantSampleCube.transform.parent = this.transform;
            _instantSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instantSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instantSampleCube;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(10, AudioPeer._samples[i] * _maxScale + 2, 10);
            }
        }

    }
}
