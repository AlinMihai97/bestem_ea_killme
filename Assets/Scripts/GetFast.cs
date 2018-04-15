using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class GetFast : MonoBehaviour {

    
    PlatformerCharacter2D playerMovement;
    ParticleSystem particleSys;
    bool powerUpIntialized;
    float seconds_count = 0;
    float max_duration = 4f;

    Platformer2DUserControl user;

    // Use this for initialization
    void Start () {
        particleSys = GetComponent<ParticleSystem>();
        playerMovement = GetComponent<PlatformerCharacter2D>();
        user = GetComponent<Platformer2DUserControl>();
        powerUpIntialized = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (EndGame.instance.isGameOver)
            return;
        if(Input.GetKeyDown(KeyCode.L))
        {
            WinLevel.instance.RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.E) && !powerUpIntialized && user.IsFocused && user.IsZombie)
        {
            playerMovement.m_MaxSpeed += 5;
            powerUpIntialized = true;
            particleSys.Emit(30);
            seconds_count = 0;
        }
        if(powerUpIntialized)
        {
            seconds_count += Time.deltaTime;
            if(seconds_count > max_duration)
            {
                deactivatePowerup();
            }
        }
	}
    public void deactivatePowerup()
    {
        if(powerUpIntialized)
        {
            powerUpIntialized = false;
            playerMovement.m_MaxSpeed -= 5;
        }
    }
}
