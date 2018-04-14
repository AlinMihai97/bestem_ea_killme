using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        bool isFocused;
        bool isZombie;

        Animator anim;
        SpriteRenderer sp;

        public Color zombiColor;
        public Color aliveColor;

        public bool IsFocused
        {
            set { isFocused = value; }
            get { return isFocused; }
        }

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            anim = GetComponent<Animator>();
            sp = GetComponent<SpriteRenderer>();
            isZombie = false;
            
        }

        void Die()
        {
            StartCoroutine(ChangeColor());
            anim.SetTrigger("Die");
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

        private void Update()
        {
            if(!isFocused)
            {
                return;
            }
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Die();
            }
        }


        private void FixedUpdate()
        {
            if(!isFocused)
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
}
