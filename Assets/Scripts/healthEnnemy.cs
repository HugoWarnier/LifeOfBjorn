using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class healthEnnemy : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	private Vector3 offset;

	private bool isActive;
	private Collider target;
	public GameObject panel;
	public Text nameEnnemy;
	public Text hp;
	public Image healthBar;
	private ennemyController eC;

	void Start ()
	{
		isActive = false;
	}

	void Update ()
	{			
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{	
			if (hit.collider.name.Contains ("ennemy") ) {
				isActive = true;
				nameEnnemy.text = hit.collider.tag;
				target = hit.collider;
				eC = hit.collider.GetComponent<ennemyController> ();
				hp.text = string.Concat( eC.currentHp.ToString(), string.Concat(" / ",eC.maxHp.ToString()));
				healthBar.fillAmount = eC.currentHp / eC.maxHp;
			}
		}
		if (isActive == true) {
			hp.text = string.Concat( eC.currentHp.ToString(), string.Concat(" / ",eC.maxHp.ToString()));
			healthBar.fillAmount = eC.currentHp / eC.maxHp;
			if (eC.currentHp <= 0) {
				isActive = false;
			}
		}
			
		panel.SetActive (isActive);

	}
}
