using UnityEngine;
using System.Collections;

public class Escalade : MonoBehaviour
{

    public GameObject player;
    public GameObject airCol;
    private Animator anim;
    private Vector2 velocity = Vector2.zero;
    private bool action = false;

    void Awake()
    {
        anim = player.GetComponent<Animator>();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if ((Input.GetAxis("Horizontal") > 0) || (Input.GetAxis("Vertical") > 0))
        {
            anim.SetBool("Escalade", true);
            action = true;
            if (action)
            {
                Vector2 target = new Vector2(player.transform.position.x + airCol.GetComponent<BoxCollider2D>().size.x, player.transform.position.y + airCol.GetComponent<BoxCollider2D>().size.y);
                player.transform.position = Vector2.SmoothDamp(player.transform.position, target, ref velocity, 0.1f);
                StartCoroutine(DelayEscalade());
            }
        }
    }

    IEnumerator DelayEscalade()
    {
        yield return new WaitForSeconds(5);
        action = false;
    }

    /*public void EscaladeAnim(GameObject player, GameObject airCol, Vector2 velocity)
    {
        if (action)
        {
            Vector2 target = new Vector2(player.transform.position.x + airCol.GetComponent<BoxCollider2D>().size.x, player.transform.position.y + airCol.GetComponent<BoxCollider2D>().size.y);
            player.transform.position = Vector2.SmoothDamp(player.transform.position, target, ref velocity, 0.1f);
            StartCoroutine(DelayEscalade());
        }
    }*/
}
