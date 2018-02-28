using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class eventMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void bbb(){
		SceneManager.LoadScene ("Demo_1");
		Debug.Log ("Button pressed");
	}
}
