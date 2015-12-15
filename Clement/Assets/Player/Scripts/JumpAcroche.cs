using UnityEngine;
using System.Collections;

public class JumpAcroche : MonoBehaviour
{

    public GameObject player;
    public float jumpForce;
    private Animator anim;

    private void Awake()
    {
        anim = player.GetComponent<Animator>();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            anim.SetBool("SuspendJump", true);
        }
        else
            anim.SetBool("SuspendJump", false);
    }
}
