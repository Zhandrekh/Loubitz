using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSelection : MonoBehaviour {

    public Transform pos;
    public GameObject head;
	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            head = other.gameObject;
            head.GetComponent<Rigidbody>().isKinematic = true;
            head.GetComponent<Rigidbody>().useGravity = false;
            head.transform.position = pos.position;
            head.transform.rotation = pos.rotation;

        }
    }
}
