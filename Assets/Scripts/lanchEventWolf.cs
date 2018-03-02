using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class lanchEventWolf : MonoBehaviour {

	public TextMesh qT;
	public TextMesh hT; 
	public Image c1;
	public Image c2;

	private int cpt;
	private bool launchDial;
	private float timeStampDial = 0;
	private bool isEnnemy;
	private bool finishedScript;

	public GameObject hero;
	public GameObject wolf;

	// Use this for initialization
	void Start () {
		cpt = 0; // Compteur pour savoir à quel étape du dialogue nous sommes
		launchDial = false; // is dialogue launch ?
		isEnnemy = false;   // is hero around wolf ?
		finishedScript = false;   // Is script finished ?
		hT.gameObject.SetActive (false);  // !display "press enter"
		c1.gameObject.SetActive (false);  // !display dialog box1
		c2.gameObject.SetActive (false);  // !display dialog box2
	}
	
	// Update is called once per frame
	void Update () {

		/*
		 *  Pré - Script / dialogue : Grognement etc ...
		 */

		if (!isEnnemy && !finishedScript) {
			launchDial = false;
			hT.gameObject.SetActive (false);
			qT.gameObject.SetActive (true);
			c1.gameObject.SetActive (false);
			c2.gameObject.SetActive (false);
		}

		/*
		 *  Post - Script / dialogue : Le loup follow Bjorn
		 */
		else if (finishedScript) {
			wolf.GetComponent<NavMeshAgent>().SetDestination (hero.transform.position);

		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			isEnnemy = false;
		}		
	}

	void OnTriggerStay(Collider other) {
		
		if (other.tag == "Player" && !finishedScript) {
			
			isEnnemy = true;
			hT.gameObject.SetActive (true);
			qT.gameObject.SetActive (false); // display "press enter" si hero a coté du loup

			moveDude mD = other.GetComponent<moveDude>() ;

			Text t1 = c1.GetComponentInChildren<Image> ().GetComponentInChildren<Text>();
			Text t2 = c2.GetComponentInChildren<Image> ().GetComponentInChildren<Text>();

			if (mD.isEnterPressed) {
				
				if (launchDial) { //si le dialogue à été lancé , affiche le dialogue suivant
					
					switch (cpt) {

					case 0: // case 0 est skip 
						t1.text = "";
						t2.text = "";
						break;

					case 1:
						t1.text = "lorem Ipsum toussa toussa";
						t2.text = "";
						break;

					case 2:
						t1.text = "";
						t2.text = "lorem Ipsum toussa toussa \n lorem Ipsum toussa toussa";
						break;

					case 3:
						t1.text = "lorem Ipsum toussa toussa\n lorem Ipsum toussa toussa\n lorem Ipsum toussa toussa";
						t2.text = "";
						break;

					default:
						launchDial = false;
						hT.gameObject.SetActive (false);
						qT.gameObject.SetActive (false);
						c1.gameObject.SetActive (false);
						c2.gameObject.SetActive (false);
						finishedScript = true;
						break;
					}
					//cooldown sur le "suivant" du dialog 
					if (timeStampDial <= Time.time){ 
						timeStampDial = Time.time + 1;
					  	cpt++;
					}
					
				} 
				//si le dialogue n'a pas été lancé , init les dialog
				else { 
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
