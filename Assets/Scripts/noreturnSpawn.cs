using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noreturnSpawn : MonoBehaviour
{

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    // Use this for initialization
    void Start()
    {
        c1.SetActive(false);
        c3.SetActive(false);
        c2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("JEPASEE");
            c1.SetActive(true);
            c3.SetActive(true);
            c2.SetActive(true);
        }
    }
}
