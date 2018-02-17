using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class ennemyController : MonoBehaviour {

	private float wanderRadius = 10;
	private float wanderTimer = 5;
	private Animator mAnimator;

	private Transform target;
	private NavMeshAgent agent;
	private float  timer;

	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<NavMeshAgent> ();
		timer = wanderTimer;
		mAnimator = GetComponent<Animator> ();
		mAnimator.SetBool ("running", true);
	}
	
	// Update is called once per frame
	void Update () {		
		timer += Time.deltaTime;

		if (timer >= wanderTimer) {
			
							
			Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
			agent.SetDestination(newPos);
			timer = 0;
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
