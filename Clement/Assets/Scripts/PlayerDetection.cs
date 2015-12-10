using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    public GameObject player;
    public GameObject head;
    public float dist;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == player.tag)
        {
            Vector2 positionLight = transform.position;
            Vector2 positionHeadPlayer = head.transform.position;
            RaycastHit2D hit = Physics2D.Linecast(positionLight, positionHeadPlayer);
            if (hit.collider.tag == player.tag)
            {
                dist = hit.distance;
                SceneManager.LoadScene(0);
            }
        }
    }
}