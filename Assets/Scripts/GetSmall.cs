﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class GetSmall : MonoBehaviour {

    bool startAnimUp = false;
    bool startAnimDown = false;
    float number_seconds = 4f;
    float seconds_counter = 0;
    ParticleSystem particleSys;
    // Use this for initialization

    Platformer2DUserControl user;

    void Start () {
        particleSys = GetComponent<ParticleSystem>();
        user = GetComponent<Platformer2DUserControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (EndGame.instance.isGameOver)
            return;
		if(Input.GetKeyDown(KeyCode.R) && !startAnimUp && !startAnimUp && user.IsFocused && user.IsZombie)
        {
            startAnimDown = true;
            seconds_counter = 0;
            particleSys.Emit(30);
        }
        if (startAnimDown)
        {
            if(seconds_counter < 10)
            {
                seconds_counter += Time.deltaTime;
                if (transform.localScale.z > 0.5)
                {
                    transform.localScale -= new Vector3(
                        0.01f*Mathf.Sign(transform.localScale.x),
                        0.01f * Mathf.Sign(transform.localScale.y),
                        0.01f * Mathf.Sign(transform.localScale.z));
                    
                }
            }
            else
            {
                seconds_counter = 0;
                startAnimDown = false;
                startAnimUp = true;
            }

        }
        if (startAnimUp)
        {
            if (seconds_counter < 3)
            {
                seconds_counter += Time.deltaTime;
                if (transform.localScale.x < 1 && transform.localScale.y < 1 && transform.localScale.z < 1)
                {
                    transform.localScale += new Vector3(
                        0.01f * Mathf.Sign(transform.localScale.x),
                        0.01f * Mathf.Sign(transform.localScale.y),
                        0.01f * Mathf.Sign(transform.localScale.z));
                }
                
            }
            else
            {
                transform.localScale = new Vector3(1*Mathf.Sign(transform.localScale.x), 1, 1);
                seconds_counter = 0;
                startAnimUp = false;
            }
        }
	}

    public void deactivatePowerup()
    {
        if(startAnimDown)
        {
            startAnimDown = false;
            seconds_counter = 0;
            startAnimUp = true;
        }
    }
}
