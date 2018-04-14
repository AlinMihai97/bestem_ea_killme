using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 1;
    public float jumpForce = 10;

    Animator anim;
    Rigidbody2D rigidbody2D;
    public BackgroundParallax background;
    bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    const string speedAnimator = "speed";
    const string groundnAnimator = "isGrounded";
    const string vSpeedAnimator = "vSpeed";

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate  () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool(groundnAnimator, grounded);
        anim.SetFloat(vSpeedAnimator, rigidbody2D.velocity.y);

        float direction = Input.GetAxis("Horizontal") * speed;
        if (facingRight && direction < 0)
        {
            Flip();
        }
        if(!facingRight && direction > 0)
        {
            Flip();
        }

        anim.SetFloat(speedAnimator, Mathf.Abs(direction));
        rigidbody2D.velocity = new Vector2(direction, rigidbody2D.velocity.y); //Vector2.right * direction;
        background.updateBackgroundPosition(direction, transform.position);

    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            anim.SetBool(groundnAnimator, false);
            rigidbody2D.AddForce(Vector2.up * jumpForce);
            Debug.Log("Jump");
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
}
