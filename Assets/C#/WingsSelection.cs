using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsSelection : MonoBehaviour {

    public GameObject wings;
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wings")
        {
            wings = other.gameObject;
        }
    }
}
