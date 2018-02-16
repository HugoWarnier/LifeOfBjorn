using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class moveDude : MonoBehaviour {

	/*
	 *  Movement
	 */

	private Animator mAnimator;
	private NavMeshAgent mAgent;
	private bool mRunning = false;

	/*
	 *  WayPointMarker
	 */

	public GameObject wayPoint;
	private GameObject currentWayPoint;
	private bool isWayPoint = false;

	/*
	 *  Attack
	 */

	public Transform spellSpawnOne;
	public Transform spellSpawnTwo;
	public Transform spellSpawnThree;
	public Transform spellSpawnFour;

	public GameObject spellOne;
	public GameObject spellTwo;
	public GameObject spellThree;
	public GameObject spellFour;

	public Image Spell1Icon;
	public Image Spell2Icon;
	public Image Spell3Icon;
	public Image Spell4Icon;

	public Sprite Spell1IconImage;
	public Sprite Spell2IconImage;
	public Sprite Spell3IconImage;
	public Sprite Spell4IconImage;

	public Sprite Spell1IconImageA;
	public Sprite Spell2IconImageA;
	public Sprite Spell3IconImageA;
	public Sprite Spell4IconImageA;

	private float timeStamp1 = 0;
	private float timeStamp2 = 0;
	private float timeStamp3 = 0;
	private float timeStamp4 = 0;

	void Start () {		
		mAnimator = GetComponent<Animator> ();
		mAgent = GetComponent<NavMeshAgent> ();
		/*
		Object tmp1A = Resources.Load("Weapon_19");

		Spell1IconImageA =  (Sprite) tmp1A;
		Spell2IconImageA;
		Spell3IconImageA;
		Spell4IconImageA;

		Object tmp1 = Resources.Load("Weapon_19_inactive");
		Spell1IconImage = (Sprite) tmp1;
		Spell2IconImage;
	    Spell3IconImage;
		Spell4IconImage;
		*/
	}

	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		/*
		 *  Click to Move  
	 	*/

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast(ray, out hit, 100 )){

				if (isWayPoint) {
					Destroy(currentWayPoint);
				}
				else{
					isWayPoint = true;
				}

				mAgent.destination = hit.point;	

				GameObject bullet = Instantiate(
					wayPoint,
					hit.point,
					new Quaternion()
					) as GameObject;				  

				currentWayPoint = bullet;
			}
		}

		if (mAgent.remainingDistance <= mAgent.stoppingDistance) {
			mRunning = false;
		} else {
			mRunning = true;
		}

		/*
		 *  Attack
	 	*/
		if (timeStamp1 <= Time.time) {			

			Spell1Icon.GetComponent<Image>().sprite = Spell1IconImageA;

			if (Input.GetKeyDown(KeyCode.Alpha1)) {			
				launchSpellOne ();
				timeStamp1 = Time.time + 1;
				Spell1Icon.GetComponent<Image>().sprite = Spell1IconImage;
			} 
		}


		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			launchSpellTwo();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			launchSpellThree();
		}

		if (timeStamp4 <= Time.time) {		

			Spell4Icon.GetComponent<Image> ().sprite = Spell4IconImageA;

			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				launchSpellFour ();
				timeStamp4 = Time.time + 3;
				Spell4Icon.GetComponent<Image> ().sprite = Spell4IconImage;
			}
		}

		mAnimator.SetBool ("running", mRunning);
	}

	void launchSpellOne (){
		
		Debug.Log ("Spell One");

		GameObject bullet = Instantiate(
			spellOne,
			spellSpawnOne.position,
			spellSpawnOne.rotation) as GameObject;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100 )){
			Vector3 v = hit.point;
			v.y = spellSpawnOne.position.y;
			bullet.transform.LookAt (v);
		}

		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

		Destroy(bullet, 2.0f);        
	}

	void launchSpellTwo(){
		
		Debug.Log ("Spell Two");

		var bullet = (GameObject)Instantiate(
			spellTwo,
			spellSpawnTwo.position,
			spellSpawnTwo.rotation);

		bullet.GetComponent<Rigidbody>().velocity = new Vector3(0,-5,0);

		Destroy(bullet, 2.0f);        
	}

	void launchSpellThree(){
		Debug.Log ("Spell Three");

		var bullet = (GameObject)Instantiate(
			spellThree,
			spellSpawnThree.position,
			spellSpawnThree.rotation);

		bullet.GetComponent<Rigidbody>().velocity = new Vector3(0,-5,0);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);        

	}

	void launchSpellFour(){
		
		Debug.Log ("Spell Three");

		var bullet1 = (GameObject)Instantiate(
			spellFour,
			spellSpawnFour.position,
			Quaternion.Euler(new Vector3(0, 0, 0)));
		
		bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * 10;

		var bullet2 = (GameObject)Instantiate(
			spellFour,
			spellSpawnFour.position,
			Quaternion.Euler(new Vector3(0, 90, 0)));
		bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * 10;

		var bullet3 = (GameObject)Instantiate(
			spellFour,
			spellSpawnFour.position,
			Quaternion.Euler(new Vector3(0, 180, 0)));
		bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * 10;

		var bullet4 = (GameObject)Instantiate(
			spellFour,
			spellSpawnFour.position,
			Quaternion.Euler(new Vector3(0, 270, 0)));
		bullet4.GetComponent<Rigidbody>().velocity = bullet4.transform.forward * 10;

		var bullet5 = (GameObject)Instantiate(
			spellFour,
			spellSpawnFour.position,
			Quaternion.Euler(new Vector3(0, 360, 0)));
		bullet5.GetComponent<Rigidbody>().velocity = bullet5.transform.forward * 10;

		Destroy(bullet1, 2.0f);    
		Destroy(bullet2, 2.0f);    
		Destroy(bullet3, 2.0f);    
		Destroy(bullet4, 2.0f);    
		Destroy(bullet5, 2.0f);    
	}
}
