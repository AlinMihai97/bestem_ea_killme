using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 1;

    Animator animator;
    Rigidbody2D rigidbody2D;
    bool facingRight = true;

    const string speedAnimator = "speed";

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        float direction = Input.GetAxis("Horizontal") * speed;
        if (facingRight && direction < 0)
        {
            Flip();
        }
        if(!facingRight && direction > 0)
        {
            Flip();
        }

        animator.SetFloat(speedAnimator, Mathf.Abs(direction));
        rigidbody2D.velocity = Vector2.right * direction;
	}

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
}
