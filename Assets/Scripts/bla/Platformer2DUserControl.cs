using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;

//namespace UnityStandardAssets._2D
//{
[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;

    bool isFocused;
    bool isZombie;

    public bool IsZombie
    {
        get { return isZombie; }
    }

    public float zombieTime = 5f;

    Animator anim;
    SpriteRenderer sp;

    public Color zombiColor;
    public Color aliveColor;

    public GameObject bloodGameObject;
    public TimerController timeController;

    bool changeFocusFromCamera = false;
    bool isZombieAndDies = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            WinLevel.instance.win = true;
        }
    }

    public bool IsFocused
    {
        set {
            isFocused = value;
            changeFocusFromCamera = value;
            }
        get { return isFocused; }
    }

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        isZombie = false;
        isFocused = false;
    }

    public void Die(bool isReviving)
    {
        if (isZombie && !isReviving)
        {
            //gameover
            EndGame.instance.GameOver();
            //isZombieAndDies = true;
            return;
        }
        Debug.Log(isZombie);
        if (!isZombie)
        {
            bloodGameObject.SetActive(false);
            bloodGameObject.SetActive(true);
        }
        StartCoroutine(ChangeColor());
        anim.SetTrigger("Die");
        

    }

    IEnumerator ChangeColor()
    {
        float nrSeconds = 2;
        float journy = 0;
        bool changeFocus = false;
        isZombie = !isZombie;
        if (isFocused)
        {
            changeFocus = true;
            isFocused = false;
        }
        while (journy < 1)
        {
            journy += Time.deltaTime / nrSeconds;
            if (!isZombie)
            {
                sp.color = Color.Lerp(aliveColor, zombiColor, journy);
            }
            else
            {
                sp.color = Color.Lerp(zombiColor, aliveColor, journy);
            }

            yield return null;
        }
        if (changeFocus && changeFocusFromCamera)
        {
            isFocused = true;
        }
       
        if (isZombie)
        {
            StartCoroutine(ReviveBack());
        }
        Debug.Log("A iesit");
    }

    IEnumerator ReviveBack()
    {
        float startTime = Time.time;
        float elepsed = Time.time - startTime;
        //isZombie = true;
        StartCoroutine(timeController.RunTimer(zombieTime));
        while (elepsed < zombieTime)
        {

            elepsed = Time.time - startTime;
            if(isZombieAndDies)
            {
                EndGame.instance.GameOver();
                break;
            }
            yield return null;
        }
        Die(true);
    }

    private void Update()
    {
        if (!isFocused || EndGame.instance.isGameOver)
        {
            return;
        }
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
        //if (Input.GetButtonDown("Fire2"))
        //{
        //    Die(false);
        //}
    }


    private void FixedUpdate()
    {
        if (!isFocused || EndGame.instance.isGameOver)
        {
            return;
        }
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}
//}
