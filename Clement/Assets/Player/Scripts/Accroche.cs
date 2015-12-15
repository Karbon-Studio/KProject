using UnityEngine;
using System.Collections;

public class Accroche : MonoBehaviour {

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GameObject handCollider;
    private float groundRadius = 0.2f;
    private bool grounded = false;
    

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded)
        {
            handCollider.SetActive(false);
        }
        if (!grounded)
        {
            if (Input.GetButton("Use/Suspend"))
            {
                handCollider.SetActive(true);
            }
            else
            {
                handCollider.SetActive(false);
            }

        }
    }
}
