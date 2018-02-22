using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullSelection : MonoBehaviour {

    public Transform pos;
    public GameObject hull;

	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hull")
        {
            hull = other.gameObject;
            hull.transform.position = pos.transform.position;
            hull.transform.rotation = pos.transform.rotation;
        }
    }
}
