using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dist;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position);
        if (hit.collider.gameObject == player)
        {
            dist = hit.distance;
        }
	}
}