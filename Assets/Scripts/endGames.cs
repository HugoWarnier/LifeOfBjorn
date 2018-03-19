using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGames : MonoBehaviour
{


    public TextMesh qT;
    public TextMesh hT;
    public GameObject boss;
    private bool isEnnemy;

    public GameObject dancing1;
    public GameObject dancing2;
    public GameObject dancing3;
    public GameObject dancing4;
    // Use this for initialization
    void Start()
    {
        isEnnemy = false;
    }

    void Update()
    {
        if (boss != null)
        {
            hT.gameObject.SetActive(false);
            qT.gameObject.SetActive(true);
            dancing1.SetActive(false);
            dancing2.SetActive(false);
            dancing3.SetActive(false);
            dancing4.SetActive(false);
        }
        else
        {
            dancing1.SetActive(true);
            dancing2.SetActive(true);
            dancing3.SetActive(true);
            dancing4.SetActive(true);
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
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            moveDude mD = other.GetComponent<moveDude>();
            isEnnemy = true;
        }
    }
}