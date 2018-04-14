using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    bool isAlive = true;
    bool isDead = false;

    public bool IsAllive
    {
        get { return isAlive; }
    }

    public bool IsDead
    {
        get { return isDead; }
    }

    public void Die()
    {
        isAlive = false;
        isDead = true;
    }

    public void Revive()
    {
        isAlive = true;
        isDead = false;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Player Manager 2 instances");
        }
        instance = this;
    }
}
