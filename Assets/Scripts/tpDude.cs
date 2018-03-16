using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpDude : MonoBehaviour {

	public TextMesh qT;
	public TextMesh hT;

	// Use this for initialization
	void Start () {
		hT.gameObject.SetActive (false); 
	}
	
	// Update is called once per frame
		void OnTriggerStay(Collider other) {
			if (other.tag == "Player") {
			
	if (mD.isEnterPressed) {}
			
			}
		}
}
