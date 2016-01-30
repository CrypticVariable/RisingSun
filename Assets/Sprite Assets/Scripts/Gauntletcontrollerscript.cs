using UnityEngine;
using System.Collections;

public class Gauntletcontrollerscript : MonoBehaviour
{
	public float maxspeed = 1.5f;
	public float speed = 1.5f;
	public float jumpForce = 150f;
	public Transform groundCheck;
	public Transform GauntletBullet;
	public LayerMask whatIsGround;

	private bool grounded = false;
	private float groundRadius = 0.2f;
	private Animator anim;
    private Rigidbody2D rb2d;
    private bool facingRight;
	private bool canFire = true;

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
			rb2d.AddForce(Vector2.up * jumpForce);
		}
		
		if(Input.GetKey(KeyCode.LeftShift))
			fire();
    }

	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("grounded", grounded);

		float h = Input.GetAxis("Horizontal");
		float newSpeed = maxspeed * h;
		
		anim.SetFloat("speed", rb2d.velocity.y);
		anim.SetFloat("speed", Mathf.Abs(h));
		
		//Changing player direction
		if(h != 0 && (h > 0) != facingRight) flip ();

        //Moving the player
		if(rb2d.velocity.x != newSpeed)
		{
			rb2d.velocity = new Vector2(newSpeed, rb2d.velocity.y);
		}
    }

    private void flip ()
    {
		facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	private void fire()
	{
		if(canFire) {
			canFire = false;
			Transform bullet = Instantiate(GauntletBullet, rb2d.position, Quaternion.identity) as Transform;
			if(bullet != null)
			{
				Vector3 dir = facingRight ? Vector3.right : Vector3.left;
				bullet.transform.Translate(dir * 0.1f); // 0.1 determined by trial-and-error...

				ShotScript shot = bullet.GetComponent<ShotScript>();
				if(shot != null) shot.SetDirection(facingRight ? "right" : "left");

				AudioSource pewpew = GetComponent<AudioSource>();
				if(pewpew != null) pewpew.Play(); // PEW PEW
			}
			Invoke("resetCooldown", 0.75f);
		}
	}

	private void resetCooldown()
	{
		canFire = true;
	}
}
