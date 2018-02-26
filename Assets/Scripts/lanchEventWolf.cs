using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class lanchEventWolf : MonoBehaviour {

	public TextMesh qT;
	public TextMesh hT;
	public Image c1;
	public Image c2;

	public int cpt;
	public bool launchDial;
	public bool isEnnemy;

	// Use this for initialization
	void Start () {
		cpt = 0;
		launchDial = false;
		isEnnemy = false;
		hT.gameObject.SetActive (false);
		c1.gameObject.SetActive (false);
		c2.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isEnnemy) {
			launchDial = false;
			hT.gameObject.SetActive (false);
			qT.gameObject.SetActive (true);
			c1.gameObject.SetActive (false);
			c2.gameObject.SetActive (false);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			isEnnemy = false;
		}		
	}

	void OnTriggerStay(Collider other) {
		
		if (other.tag == "Player") {
			
			isEnnemy = true;
			hT.gameObject.SetActive (true);
			qT.gameObject.SetActive (false);

			moveDude mD = other.GetComponent<moveDude>() ;

			if (mD.isEnterPressed) {

				if (launchDial) {
					
					switch (cpt) {
					case 0:
						cpt++;
						break;

					case 1:
						cpt++;
						break;

					case 2:
						;
						break;

					default:
						break;
					}
					
				} else {
					launchDial = true;
					hT.gameObject.SetActive (false);
					qT.gameObject.SetActive (false);
					c1.gameObject.SetActive (true);
					c2.gameObject.SetActive (true);
				}
			}
		}
	}
}
