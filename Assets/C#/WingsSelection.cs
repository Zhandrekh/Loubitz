using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsSelection : MonoBehaviour {

    public Transform pos;
    public GameObject wings;
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wings")
        {
            wings = other.gameObject;
            wings.transform.position = pos.position;
            wings.transform.rotation = pos.rotation;
        }
    }
}
