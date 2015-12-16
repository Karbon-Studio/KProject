using UnityEngine;
using System.Collections;
using System;

public class jumpTest : MonoBehaviour
{
    public GameObject player;
    public float y;
    public bool canJump = true;

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(move * 5, player.GetComponent<Rigidbody2D>().velocity.y);
        Vector2 jump = new Vector2(0, 30 /** Input.GetAxis("Vertical")*/);
        y = jump.y;
        if(Input.GetButton("Jump") && canJump)
        {
            player.GetComponent<Rigidbody2D>().AddForce(jump);
            //canJump = false;
            StartCoroutine(JumpPower());
        }
        if(!canJump && (player.GetComponent<Rigidbody2D>().velocity.y == 0))
        {
            StartCoroutine(DelayJump());
        }
    }

    private IEnumerator JumpPower()
    {
        yield return new WaitForSeconds(0.3f);
        canJump = false;
    }

    private IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }
}