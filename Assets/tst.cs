using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tst : MonoBehaviour {


	void OnGUI()
	{

		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);

		GUI.Box(new Rect(targetPos.x, Screen.height- 10, 60, 20), 80 + "/" + 100);

	}

}
