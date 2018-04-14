using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSmall : MonoBehaviour {

    bool startAnimUp = false;
    bool startAnimDown = false;
    float number_seconds = 5;
    float seconds_counter = 0;
    ParticleSystem particleSys;
    // Use this for initialization
    void Start () {
        particleSys = GetComponent<ParticleSystem>();   
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R) && !startAnimUp && !startAnimUp)
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
                if (transform.localScale.x < 1)
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
