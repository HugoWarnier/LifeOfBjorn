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

	public void startGame(){
		// Lance le Jeu
		SceneManager.LoadScene ("Demo_1");
		Debug.Log ("Start");
	}

	public void optionsGame(){		
		// Option du jeu *TODO*
		Debug.Log ("Options");
	}

	public void quitGame(){		
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
