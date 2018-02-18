using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectEnnemy : MonoBehaviour {

	public Vector3 pos;
	public bool isEnnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print (string.Concat("Is Ennemy1 : ",isEnnemy));

	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			pos = other.transform.position;
			isEnnemy = true;
		}
	}
}
