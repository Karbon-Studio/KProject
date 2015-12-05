using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

public float Speed = 0f;
private float movex = 0f;
private float movey = 0f;

private Rigidbody2D rigidbody2D;

// Use this for initialization
void Start () {
	rigidbody2D = GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void FixedUpdate () {
movex = Input.GetAxis ("Horizontal");
movey = Input.GetAxis ("Vertical");
rigidbody2D.velocity = new Vector2 (movex * Speed, movey * Speed);
}
}
