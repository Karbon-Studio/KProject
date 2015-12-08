using UnityEngine;
using System.Collections;

public class Accroche : MonoBehaviour {

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GameObject handCollider;
    private float groundRadius = 0.2f;
    private bool grounded = false;
    

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
