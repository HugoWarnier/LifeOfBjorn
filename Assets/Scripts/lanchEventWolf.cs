using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class lanchEventWolf : MonoBehaviour {

	public TextMesh qT;
	public TextMesh hT; 
	public Image c1;
	public Image c2;
	public Image c3;

	private int cpt;
	private bool launchDial;
	private float timeStampDial = 0;
	private bool isEnnemy;
	private bool finishedScript;

	private bool choice;	
	private bool mm;


	public GameObject hero;
	public GameObject wolf;
	public GameObject barbarian;

	// Use this for initialization
	void Start () {
		cpt = 0; // Compteur pour savoir à quel étape du dialogue nous sommes
		launchDial = false; // is dialogue launch ?
		isEnnemy = false;   // is hero around wolf ?
		finishedScript = false;   // Is script finished ?
		hT.gameObject.SetActive (false);  // !display "press enter"
		c1.gameObject.SetActive (false);  // !display dialog box1
		c2.gameObject.SetActive (false);  // !display dialog box2
		c3.gameObject.SetActive (false);  // !display dialog box2
		mm = false;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		 *  Pré - Script / dialogue : Grognement etc ...
		 */
		Debug.Log (cpt);
		if (!isEnnemy && !finishedScript) {
			launchDial = false;
			hT.gameObject.SetActive (false);
			qT.gameObject.SetActive (true);
			c1.gameObject.SetActive (false);
			c2.gameObject.SetActive (false);
			c3.gameObject.SetActive (false);
		}
		else if(isEnnemy && !finishedScript && cpt == 3){
			if (Input.GetKeyDown (KeyCode.A)) {
				Debug.Log ("INPUTA");
				mm = true;
				choice = true;
			} else if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("INPUTE");
				mm = true;
				choice = false;
			}
		}
		/*
		 *  Post - Script / dialogue : Le loup follow Bjorn
		 */
		else if (finishedScript) {
			if (choice) {
				wolf.GetComponent<NavMeshAgent> ().SetDestination (hero.transform.position);
				Destroy (barbarian.gameObject);
			} else {
				barbarian.GetComponent<NavMeshAgent> ().SetDestination (hero.transform.position);
				Destroy (wolf.gameObject);
			}
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
			Text t3 = c3.GetComponentInChildren<Image> ().GetComponentInChildren<Text>();

			if ((mD.isEnterPressed && cpt != 4) || mm) {
				
				if (launchDial) { //si le dialogue à été lancé , affiche le dialogue suivant
					
					switch (cpt) {

					case 0: // case 0 est skip 
						t1.text = "";
						t2.text = "";
						t3.text = "";
						break;

					case 1:
						
						c1.gameObject.SetActive (false);
						c2.gameObject.SetActive (false);
						t3.text = "Au secours un loup m'attaque !";
						break;

					case 2:
						t1.text = "";
						c3.gameObject.SetActive (false);
						c2.gameObject.SetActive (true);
						t2.text = "Grou Grou \n *le loup essaye de se défendre*";
						break;

					case 3:
						c3.gameObject.SetActive (false);
						c2.gameObject.SetActive (false);
						c1.gameObject.SetActive (true);
						t1.text = "Appuis sur A pour Aider le loup, appuie sur E pour aider le chasseur";
						break;

					default:
						launchDial = false;
						hT.gameObject.SetActive (false);
						qT.gameObject.SetActive (false);
						c1.gameObject.SetActive (false);
						c2.gameObject.SetActive (false);
						c3.gameObject.SetActive (false);
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
					c3.gameObject.SetActive (true);
				}
			}
		}
	}


	public void OnPointerClick(PointerEventData eventData) // 3
	{
		Debug.Log("I was clicked");

	}
}
