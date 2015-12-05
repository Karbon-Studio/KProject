using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject m_Player;
	public float m_CameraSpeed = 0.5f;
	private int m_Direction = 1;

	void Awake()
	{
		transform.position = m_Player.transform.position;
	}

	void Update()
	{
		Vector2 pos = Vector2.Lerp(transform.position, m_Player.transform.position + new Vector3(3 * m_Direction, 0, 0), m_CameraSpeed * Time.deltaTime);
		transform.position = new Vector3(pos.x, pos.y, -10);
	}
	
}
