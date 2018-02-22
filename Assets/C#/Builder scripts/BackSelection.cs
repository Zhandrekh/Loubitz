using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSelection : MonoBehaviour {

    public Transform pos;
    public GameObject refBack;
    public GameObject back;


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Back")
        {
            back = other.gameObject;
            refBack = other.GetComponent<BackReferance>().backRef;
            back.GetComponent<Rigidbody>().isKinematic = true;
            back.GetComponent<Rigidbody>().useGravity = false;
            back.transform.parent = this.transform;
            back.transform.position = pos.position;
            back.transform.rotation = pos.rotation;
        }
    }
}
