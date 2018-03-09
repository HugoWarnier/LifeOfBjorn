using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButtonController : MonoBehaviour {

	public void Continuer(){
		gameController gC = GetComponentInParent<gameController> ();
		gC.resume = true;
	}

	public void Save(){
	}

	public void Quit(){
		Debug.Log ("Quit");
		Application.Quit ();
	}

}
