using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{

    public bool checkpoint = false;
    public bool recupHeal = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == player.tag)
        {
            checkpoint = true;
            recupHeal = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == player.tag)
        {
            checkpoint = false;
            recupHeal = false;
        }

    }
}
