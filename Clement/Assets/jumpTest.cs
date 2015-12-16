using UnityEngine;
using System.Collections;

public class jumpTest : MonoBehaviour
{
    public GameObject player;
    public float y;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(move * 5, player.GetComponent<Rigidbody2D>().velocity.y);
        Vector2 jump = new Vector2(0, Input.GetAxis("Vertical"));
        y = jump.y;
        if(Input.GetButton("Jump"))
        {
            player.GetComponent<Rigidbody2D>().AddForce(jump);

        }
    }
}
