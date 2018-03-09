using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class moveDude : MonoBehaviour {

	/*
	 * GUI
	 */

	public Image Spell1Icon;
	public Image Spell2Icon;
	public Image Spell3Icon;
	public Image Spell4Icon;

	public Text Cooldown1;
	public Text Cooldown2;
	public Text Cooldown3;
	public Text Cooldown4;

	public Sprite Spell1IconImage;
	public Sprite Spell2IconImage;
	public Sprite Spell3IconImage;
	public Sprite Spell4IconImage;

	public Sprite Spell1IconImageA;
	public Sprite Spell2IconImageA;
	public Sprite Spell3IconImageA;
	public Sprite Spell4IconImageA;


	//private float MaxHpPlayer = 100;
	private float HpPlayer = 80;
	public Image healthBar;
	public Text healthPoint;

	//private float MaxManaPlayer = 100;
	private float ManaPlayer = 60;
	public Image ManaBar;
	public Text ManaPoint;

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
	//public Transform spellSpawnThree;
	public Transform spellSpawnFour;

	private GameObject autoAttack;
	public GameObject spellOne;
	public GameObject spellTwo;
	//public GameObject spellThree;
	public GameObject spellFour;

	private float timeStamp1 = 0;
	private float timeStamp2 = 0;
	private float timeStamp3 = 0;
	private float timeStamp4 = 0;

	/*
	 * Events 
	 */

	public bool isEnterPressed;
	private float timeStampEnter = 0;

	void Start () {		
		mAnimator = GetComponent<Animator> ();
		mAgent = GetComponent<NavMeshAgent> ();
		isEnterPressed = false;

		autoAttack = GameObject.Find ("triggerAttackHero");
		autoAttack.SetActive (false);
	}

	void Update ()
	{
		/*
		 *  Events
		 */

		if (Input.GetKey (KeyCode.Return)) {
			Debug.Log ("0");
			isEnterPressed = true;
			timeStampEnter = Time.time + 0.5f;
		}
		if (timeStampEnter <= Time.time) {
			isEnterPressed = false;
		}


		/*
		 *  Click to Move  
	 	*/

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

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

		mAnimator.SetBool ("running", mRunning);

		/*
		 *  Attack
	 	*/
		if (timeStamp1 <= Time.time) {

			Text myText = Cooldown1.GetComponent<Text> ();
			myText.text =  "";

			Spell1Icon.GetComponent<Image>().sprite = Spell1IconImageA;
			if (Input.GetKeyDown(KeyCode.Alpha1)) {			
				launchSpellOne ();
				timeStamp1 = Time.time + 1;
				Spell1Icon.GetComponent<Image>().sprite = Spell1IconImage;
			} 
		} else {
			Text myText = Cooldown1.GetComponent<Text> ();
			myText.text =  (Mathf.Round(timeStamp1-Time.time)).ToString();	
		}

		if (timeStamp2 <= Time.time) {	
			
			Text myText = Cooldown2.GetComponent<Text> ();
			myText.text =  "";

			Spell2Icon.GetComponent<Image>().sprite = Spell2IconImageA;
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				launchSpellTwo ();
				timeStamp2 = Time.time + 1;
				Spell2Icon.GetComponent<Image> ().sprite = Spell2IconImage;
			}		
		} else {
			Text myText = Cooldown2.GetComponent<Text> ();
			myText.text =  (Mathf.Round(timeStamp2-Time.time)).ToString();	
		}

		if (timeStamp3 <= Time.time) {

			Text myText = Cooldown3.GetComponent<Text> ();
			myText.text =  "";

			Spell3Icon.GetComponent<Image>().sprite = Spell3IconImageA;
			if (Input.GetKeyDown(KeyCode.Alpha3)) {			
				launchSpellThree ();
				timeStamp3 = Time.time + 2;
				Spell3Icon.GetComponent<Image>().sprite = Spell3IconImage;
			} 
		} else {
			mAnimator.SetBool ("attack", false);
			autoAttack.SetActive (false);        
			Text myText = Cooldown3.GetComponent<Text> ();
			myText.text =  (Mathf.Round(timeStamp3-Time.time)).ToString();	
		}

		if (timeStamp4 <= Time.time) {	
			
			Text myText = Cooldown4.GetComponent<Text> ();
			myText.text =  "";

			Spell4Icon.GetComponent<Image> ().sprite = Spell4IconImageA;

			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				launchSpellFour ();
				timeStamp4 = Time.time + 3;
				Spell4Icon.GetComponent<Image> ().sprite = Spell4IconImage;
			}
		} else {
			
			Text myText = Cooldown4.GetComponent<Text> ();
			myText.text =  (Mathf.Round(timeStamp4-Time.time)).ToString();	
		}

		/*
		 *  Health Management
		 */ 

		healthPoint.text = HpPlayer.ToString();
		healthBar.fillAmount = HpPlayer/100;

		ManaPoint.text = ManaPlayer.ToString();
		ManaBar.fillAmount = ManaPlayer/100;

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

		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;

		Destroy(bullet, 2.0f);        
	}

	void launchSpellTwo(){
		
		Debug.Log ("Spell Two");

		var bullet = (GameObject)Instantiate(
			spellTwo,
			spellSpawnTwo.position,
			spellSpawnTwo.rotation);		
	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100 )){
			Vector3 v = hit.point;
			v.y = spellSpawnTwo.position.y;
			bullet.transform.LookAt (v);
		}

		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 30;
		bullet.GetComponent<Rigidbody> ().AddTorque(new Vector3(0, 10000,0));

		Destroy(bullet, 2.0f);        
	}

	void launchSpellThree(){
		
		mAnimator.SetBool ("attack", true);
		autoAttack.SetActive (true);        

	}

	void launchSpellFour(){
		
		Debug.Log ("Spell Four");

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

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Fire") {
			HpPlayer -= 10;
		}
	}
}
