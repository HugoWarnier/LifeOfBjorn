using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tpDude : MonoBehaviour {

	public TextMesh qT;
	public TextMesh hT;

    private bool isEnnemy;
    // Use this for initialization
    void Start () {
        isEnnemy = false;
	}

    void Update()
    {
        if (!isEnnemy)
        {
            hT.gameObject.SetActive(false);
            qT.gameObject.SetActive(true);
        } else
        {
            hT.gameObject.SetActive(true);
            qT.gameObject.SetActive(false);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isEnnemy = false;
        }
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other) {
			if (other.tag == "Player") {
                moveDude mD = other.GetComponent<moveDude>();
                isEnnemy = true;
                if (mD.isEnterPressed) {
                    SceneManager.LoadScene("indoorTest", LoadSceneMode.Single);
                }			
			}
		}
}
