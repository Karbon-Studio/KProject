using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour
{

    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == player.tag) // si le joueur entre dans le collider
        {
            Vector3 relPlayerPos = player.transform.position - transform.position;
            float angle = Vector3.Angle(relPlayerPos, transform.forward);
            if (angle < 63.5)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position);
                if (hit.collider.tag == player.tag)  // si le joueur est touchable par la lumiere dans le collider
                    Application.LoadLevel(0);//dead
                
            }
        }
    }
}