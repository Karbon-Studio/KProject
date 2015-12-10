using UnityEngine;
using System.Collections;

public class TestDetection : MonoBehaviour
{


    public GameObject player;
    public float distance;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position);
        if (hit.collider.tag == player.tag)
            distance = hit.distance;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == player.tag)
        {


        }

    }
}
