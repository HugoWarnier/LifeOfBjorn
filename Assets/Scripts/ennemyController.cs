using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "spell_one") {
			Destroy (this.gameObject);
		}
		else if (other.tag == "spell_two") {
			Destroy (this.gameObject);
		}
		else if (other.tag == "spell_three") {
			Destroy (this.gameObject);
		}
		else if (other.tag == "spell_four") {
			Destroy (this.gameObject);
		}
	}
}
