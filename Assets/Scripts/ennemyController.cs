using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ennemyController : MonoBehaviour {


	// périmètre dans lequel se déplace le pnj
	private float wanderRadius = 10;   

	// temps pendant lequel se déplace le pnj
	private float wanderTimer = 5;

	private Animator mAnimator;

	public float currentHp;
	public float maxHp;

	// prefabs de l'affichage des dégats sur les ennemis
	public TextMesh dealDamage;
	// cooldown displayDamage
	private float displayDamage = 0;
	public Camera playerCamera;

	// variable pour gérer le cooldown des ennemis
	private float timeStamp = 0;
	// hitBox de l'auto attack un gameobject avec juste une sphere collider + rigidbody 
	private GameObject autoAttack;

	// Ennemy detections
	private detectEnnemy detection;
	private bool isEnnemy;
	private Transform target;
	private NavMeshAgent agent;
	private float  timer;

	void Start(){
		autoAttack = GameObject.Find ("triggerAttack");
		autoAttack.SetActive (false);
	}

	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		timer = wanderTimer;
		mAnimator = GetComponent<Animator> ();
		mAnimator.SetBool ("running", true);
	}
	
	void Update () {	
		//Mort de l'ennemi
		if (currentHp <= 0) {
			Destroy (this.gameObject);
		} else if (currentHp > 0){
				
			detection = GetComponentInChildren<detectEnnemy> ();
			isEnnemy = detection.isEnnemy;

			if (isEnnemy) {
				Vector3 t = detection.pos;
				agent.SetDestination (t);

				if (timeStamp <= Time.time) {
					autoAttack.SetActive (true);
					timeStamp = Time.time + 1;
					mAnimator.SetBool ("attack", true);
				} else {
					mAnimator.SetBool ("attack", false);
					autoAttack.SetActive (false);
				}

			} else {
				timer += Time.deltaTime;
				if (timer >= wanderTimer) {							
					Vector3 newPos = RandomNavSphere (transform.position, wanderRadius, -1);
					agent.SetDestination (newPos);
					timer = 0;
				}
			}
		}
			

			/*
			if (displayDamage <= Time.time) {
				displayDamage = Time.time + 0.50f;
				dealDamage.text = " ";
			}*/

	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {		
		Vector3 randDirection = Random.insideUnitSphere * dist;
		randDirection += origin;
		NavMeshHit navHit;
		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
		return navHit.position;
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "spell_one") {
			currentHp -= 20;
			TextMesh damageIndicator = createDamageIndicator (20);
			Destroy(damageIndicator.GetComponent<GameObject>(), 1.0f);
		}
		else if (other.tag == "spell_two") {
			currentHp -= 20;
			TextMesh damageIndicator = createDamageIndicator (20);
			Destroy(damageIndicator.GetComponent<GameObject>(), 1.0f);
		}
		else if (other.tag == "spell_three") {
			TextMesh damageIndicator = createDamageIndicator (10);
			Destroy(damageIndicator.GetComponent<GameObject>(), 1.0f);
			currentHp -= 10;
		}
		else if (other.tag == "spell_four") {
			TextMesh damageIndicator = createDamageIndicator (20);
			currentHp -= 20;
			Destroy(damageIndicator.GetComponent<GameObject>(), 1.0f);
		}	   

	}

	TextMesh createDamageIndicator(int damage){
		
		Debug.Log ("damageHit");

		// élève de 5 UnityUnit le damageIndicator au dessus de l'ennemi
		Vector3 vect = transform.position;
		vect.y = vect.y + 5;

		var damageIndicator = (TextMesh)Instantiate(
			dealDamage,
			vect,
			transform.rotation);

		// rotation pour faire apparaitre le damageIndicator toujours face à la camera
		damageIndicator.transform.LookAt(playerCamera.transform);
		damageIndicator.transform.Rotate(Vector3.up - new Vector3(0,180,0));

		//affichage dégats 
		damageIndicator.text = string.Concat("-",damage.ToString());

		//donne effets à damageIndicator
		damageIndicator.GetComponent<Rigidbody>().velocity = new Vector3(0,5,0);

		return damageIndicator;
	}

}
