using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSelection : MonoBehaviour {

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
        }
    }
}
