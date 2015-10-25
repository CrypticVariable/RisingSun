using UnityEngine;
using System.Collections;

public class Gauntletcontrollerscript : MonoBehaviour
{
    Animator anim;
    public float maxspeed = 10;
    public float speed = 50f;
    public float jumpForce = 250f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private Rigidbody2D rb2d;
    private bool facingRight;

    void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("grounded", false);
            rb2d.AddForce(new Vector2(0, jumpForce));
        }


    }
	void FixedUpdate ()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", rb2d.velocity.y);

        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(h));

        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        //Limiting player speed
        if (rb2d.velocity.x > maxspeed)
        {
            rb2d.velocity = new Vector2(maxspeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxspeed)
        {
            rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
        }

        //Changing player direction
        if (h > 0 && !facingRight)
            flip();
        else if (h < 0 && facingRight)
            flip();
    }

    void flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
