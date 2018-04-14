using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;

    bool isDead;
    bool isFocused;

    public bool IsFocused
    {
        set { isFocused = value; }
        get { return isFocused; }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        Revive();
    }

    void Die()
    {
        isDead = true;
        UpdateAnim();
    }

    void UpdateAnim()
    {
        anim.SetBool("isDead", isDead);
    }

    void Revive()
    {
        isDead = false;
        UpdateAnim();
    }

    private void Update()
    {
        if(isFocused)
        {
            if (Input.GetButtonDown("Fire2") && !isDead)
            {
                Die();
                anim.SetTrigger("Die");
            }
            if (Input.GetButtonDown("Fire3") && isDead)
            {
                Revive();
                anim.SetTrigger("Revive");
            }
        }
    }

    void unFocus()
    {
        isFocused = false;
    }
}
