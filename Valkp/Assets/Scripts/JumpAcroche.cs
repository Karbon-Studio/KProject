using UnityEngine;
using System.Collections;

public class JumpAcroche : MonoBehaviour {

    public GameObject player;
    public float jumpForce;

    void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetButtonDown("Jump") && (other.gameObject.tag == "Rebord"))
        {
            PlayerControllerScripts playerJ;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
}
