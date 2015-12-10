using UnityEngine;
using System.Collections;

public class PlayerControllerScripts : MonoBehaviour
{

    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float jumpForceMax;
    public float jumpForceAddFrame;
    public float delayRecupJump;
    //public float friction;
    public GameObject walkCollider;
    public GameObject crouchCollider;
    public GameObject airCollider;
    public GameObject rollCollider;

    // Whether or not a player can steer while jumping;
    private float groundRadius = 0.2f;
    private float jumpSpeed;
    private float jump;
    private bool facingRight = true;
    private bool grounded = false;
    private bool jumping = false;
    private bool delayJump = true;
    private Animator anim;
    private Rigidbody2D m_Rigidbody2D;



    private void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        walkCollider.SetActive(true);
        crouchCollider.SetActive(false);
        airCollider.SetActive(false);
        rollCollider.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float crouch = Input.GetAxis("Crouch");
        float run = Input.GetAxis("Run");

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        if (grounded)
        {

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move * walkSpeed, m_Rigidbody2D.velocity.y);
            jumpSpeed = walkSpeed;

            walkCollider.SetActive(true);
            crouchCollider.SetActive(false);
            airCollider.SetActive(false);
            rollCollider.SetActive(false);


            //Sprint speed

            if (run == 1 || Input.GetButton("Run"))
            {
                anim.SetBool("Run", true);
                m_Rigidbody2D.velocity = new Vector2(move * runSpeed, m_Rigidbody2D.velocity.y);
                jumpSpeed = runSpeed;
                if (crouch == 1 || Input.GetButton("Crouch"))
                    anim.SetBool("Roll", true);
                else
                    anim.SetBool("Roll", false);
            }
            else
            {
                anim.SetBool("Run", false);
                anim.SetBool("Roll", false);
            }

            if (this.GetComponent<SpriteRenderer>().sprite.name.Substring(0, 12) == "RobotBoyRoll")
            {
                walkCollider.SetActive(false);
                crouchCollider.SetActive(false);
                airCollider.SetActive(false);
                rollCollider.SetActive(true);
            }

            //Crouch player

            if (crouch == 1 || Input.GetButton("Crouch"))
            {
                m_Rigidbody2D.velocity = new Vector2(move * crouchSpeed, m_Rigidbody2D.velocity.y);
                jumpSpeed = crouchSpeed;

                walkCollider.SetActive(false);
                crouchCollider.SetActive(true);
                airCollider.SetActive(false);
                rollCollider.SetActive(false);

                if (run == 1 || Input.GetButton("Run"))
                {
                    m_Rigidbody2D.velocity = new Vector2(move * runSpeed, m_Rigidbody2D.velocity.y);
                    anim.SetBool("Roll", true);
                    rollCollider.SetActive(true);
                    crouchCollider.SetActive(false);
                }
                else
                    anim.SetBool("Roll", false);

                anim.SetBool("Crouch", true);
            }
            else
            {
                anim.SetBool("Crouch", false);
            }

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

        //perte de vitesse en l'air
        if (!grounded)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(move));
            m_Rigidbody2D.velocity = new Vector2(move * jumpSpeed, m_Rigidbody2D.velocity.y);
            /* if (facingRight && Mathf.Abs(move) > 0)
             {
                 // Move the character
                 m_Rigidbody2D.velocity = new Vector2(move * jumpSpeed - friction, m_Rigidbody2D.velocity.y);
             }
             else if (Mathf.Abs(move) > 0 && !facingRight)
             {
                 // Move the character
                 m_Rigidbody2D.velocity = new Vector2(move * jumpSpeed + friction, m_Rigidbody2D.velocity.y);
             }*/

            if (Input.GetButton("Use/Suspend"))
            {
                anim.SetBool("Suspend", true);
            }
            else
            {
                anim.SetBool("Suspend", false);
            }


            walkCollider.SetActive(false);
            crouchCollider.SetActive(false);
            airCollider.SetActive(true);
            rollCollider.SetActive(false);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight)
            {
                // ... flip the player.
                Flip();
            }            
        }

        //Jump gestion  

        if (jumping && (jump <= jumpForceMax))
        {
            if (delayJump)
            {
                m_Rigidbody2D.AddForce(new Vector2(0, jumpForceAddFrame));
                jump += jumpForceAddFrame;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(jumping)
        {
            delayJump = false;
            StartCoroutine(DelayJump());
            jumping = false;
            jump = 0;
        }
    }

    IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(delayRecupJump);
        delayJump = true;
    }

    void Update()
    {
        if (grounded && Input.GetButton("Jump"))
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
