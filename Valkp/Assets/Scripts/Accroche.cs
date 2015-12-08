using UnityEngine;
using System.Collections;

public class Accroche : MonoBehaviour {

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GameObject player;
    public GameObject handCollider;
    private float groundRadius = 0.2f;
    private bool grounded = false;
    public float jumpForce;

    private void Awake()
    {
    }

  /*  void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Rebord")
        {
            if (Input.GetButtonDown("Use/Suspend"))
            {
                GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }*/

    void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetButtonDown("Jump") && (other.gameObject.tag == "Rebord"))
        {
            PlayerControllerScripts playerJ;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded)
        {
            handCollider.SetActive(false);
        }
        if (Input.GetButtonDown("Use/Suspend"))
        {
            handCollider.SetActive(true);
        }
        else if (Input.GetButtonUp("Use/Suspend"))
        {
            handCollider.SetActive(false);
        }
    }
}
