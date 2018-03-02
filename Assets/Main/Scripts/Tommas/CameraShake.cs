﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    [Range(0,10)]
    public float power = 0.7f;

    public float duration = 0.1f;
    public Transform camera;
    public float slowDownTime = 1.0f;
    public bool shouldShake = false;

    Vector3 startingPostion;
    public float intialDuration;
    public float LerpSpeed;

    public Transform targetPlayer;
    public float smoothingSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 offset_death;

    //Takk for støtten tommas, digger at du følger med!

    public GameObject GAmeOVer;
    public GameObject Victory;

    // Use this for initialization
    void Start () {
        camera = Camera.main.transform;
        transform.position = Vector3.Lerp(targetPlayer.position + offset_death, transform.position + offset, LerpSpeed);
        intialDuration = duration; 

	}
    private void FixedUpdate()
    {
        Vector3 desierdPosition = targetPlayer.position + offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desierdPosition, smoothingSpeed);
        transform.position = smoothedPostion;
    }

    // Update is called once per frame
    public void Update ()
    {
        if (shouldShake)
        {
            Shaking();
        } 
	}

    public void Zooming()
    {
        camera.localPosition = Vector3.Lerp(transform.position + offset, targetPlayer.position + offset_death, LerpSpeed);
    }

    public void Shaking()
    {
        if (duration > 0)
        {
            camera.localPosition = camera.localPosition + Random.insideUnitSphere * power;
            duration -= Time.deltaTime * slowDownTime;
        }
    }
}
