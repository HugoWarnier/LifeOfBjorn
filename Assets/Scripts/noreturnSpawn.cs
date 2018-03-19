using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noreturnSpawn : MonoBehaviour
{

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject player;
    public UnityEngine.AI.NavMeshAgent mAgent;
    private moveDude mD;

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    private bool declanched = false;
    Vector3 originalPos;

    // Use this for initialization
    void Start()
    {
        mAgent = player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        mD = player.GetComponent<moveDude>();
        c1.SetActive(false);
        c3.SetActive(false);
        c2.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            mD.enabled = true;
            shakeDuration = 0f;
            originalPos = camTransform.localPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && !declanched)
        {
            declanched = true;
            mD.enabled = false;
            mAgent.SetDestination(player.transform.position);
            shakeDuration = 3;
            c1.SetActive(true);
            c3.SetActive(true);
            c2.SetActive(true);
        }
    }
}
