using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;

    bool isDead;
    bool isFocused;
    bool isZombie;

    SpriteRenderer sp;

    public Color zombiColor;
    public Color aliveColor;

    public bool IsFocused
    {
        set { isFocused = value; }
        get { return isFocused; }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        isZombie = false;
        Revive();
    }

    void Die()
    {
        StartCoroutine(ChangeColor());
        UpdateAnim();

    }

    IEnumerator ChangeColor()
    {
        float nrSeconds = 2;
        float journy = 0;
        bool changeFocus = false;
        if (isFocused)
        {
            changeFocus = true;
            isFocused = false;
        }
        while (journy < 1)
        {
            journy += Time.deltaTime / nrSeconds;
            Debug.Log(journy);
            if (isZombie)
            {
                sp.color = Color.Lerp(aliveColor, zombiColor, journy);
            }
            else
            {
                sp.color = Color.Lerp(zombiColor, aliveColor, journy);
            }

            yield return null;
        }
        if (changeFocus)
        {
            isFocused = true;
        }
        isZombie = !isZombie;
        Debug.Log("A iesit");
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
        }
    }

    void unFocus()
    {
        isFocused = false;
    }
}
