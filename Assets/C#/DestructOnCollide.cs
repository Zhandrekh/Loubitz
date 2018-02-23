using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructOnCollide : MonoBehaviour {

    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Avion")
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
