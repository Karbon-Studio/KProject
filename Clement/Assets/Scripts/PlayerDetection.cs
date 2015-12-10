using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    public GameObject player;
    public GameObject head;
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == player.tag) // si le joueur entre dans le collider
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, head.transform.position);
            if (hit.collider.tag == player.tag)  // si le joueur est touchable par la lumiere dans le collider
                SceneManager.LoadScene(0); //dead
        }
    }
}