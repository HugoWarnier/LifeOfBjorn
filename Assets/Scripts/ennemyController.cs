using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ennemyController : MonoBehaviour {

	private float wanderRadius = 10;
	private float wanderTimer = 5;
	private Animator mAnimator;

	public float currentHp;
	public float maxHp;

	private detectEnnemy detection;
	private bool isEnnemy;

	private Transform target;
	private NavMeshAgent agent;
	private float  timer;


	void Start(){
		
	}

	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		timer = wanderTimer;
		mAnimator = GetComponent<Animator> ();
		mAnimator.SetBool ("running", true);
	}
	
	// Update is called once per frame
	void Update () {	

		detection = GetComponentInChildren<detectEnnemy> ();
		isEnnemy = detection.isEnnemy;
		print (string.Concat("Is Ennemy2 : ",isEnnemy));

		if (isEnnemy) {
			Vector3 t = detection.pos;
			agent.SetDestination (t) ;			
		} else {
			timer += Time.deltaTime;
			if (timer >= wanderTimer) {							
				Vector3 newPos = RandomNavSphere (transform.position, wanderRadius, -1);
				agent.SetDestination (newPos);
				timer = 0;
			}
		}

		if (currentHp <= 0) {
			Destroy (this.gameObject);
		}
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
		}
		else if (other.tag == "spell_two") {
			currentHp -= 20;
		}
		else if (other.tag == "spell_three") {
			currentHp -= 20;
		}
		else if (other.tag == "spell_four") {
			currentHp -= 20;
		}
	}
}
