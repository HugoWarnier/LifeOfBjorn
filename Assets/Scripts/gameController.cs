using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

	private bool isPlay;
	public bool resume;

	public GameObject t;
	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;

	public GameObject Im;


	//Script à desactiver pnd la pause
	public GameObject player;
	private moveDude mD;

	// Use this for initialization
	void Start () {
		isPlay = false;
		resume = false;
		mD = player.GetComponent<moveDude> ();

		t.SetActive (false);
		t1.SetActive (false);
		t2.SetActive (false);
		t3.SetActive (false);
		t4.SetActive (false);

		Im.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			if (isPlay) {	
				Time.timeScale = 1;
				mD.enabled = true;
				t.SetActive (false);
				t1.SetActive (false);
				t2.SetActive (false);
				t3.SetActive (false);
				t4.SetActive (false);
				Im.SetActive (false);
			} else {
				Time.timeScale = 0;
				mD.enabled = false;
				t.SetActive (true);
				t1.SetActive (true);
				t2.SetActive (true);
				t3.SetActive (true);
				t4.SetActive (true);
				Im.SetActive (true);

			}
			isPlay = !isPlay;

		} else if (resume) {
			Time.timeScale = 1;
			mD.enabled = true;
			isPlay = false;
			resume = false;
			t.SetActive (false);
			t1.SetActive (false);
			t2.SetActive (false);
			t3.SetActive (false);
			t4.SetActive (false);
			Im.SetActive (false);

		} 				
	}
}
