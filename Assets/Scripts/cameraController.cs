using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	Ray ray;
	RaycastHit hit;
	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}