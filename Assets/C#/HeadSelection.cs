using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSelection : MonoBehaviour {

    public Transform pos;
    public GameObject refHead;
    public GameObject head;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            head = other.gameObject;
            refHead = other.GetComponent<HeadReferance>().headRef;
            head.GetComponent<Rigidbody>().isKinematic = true;
            head.GetComponent<Rigidbody>().useGravity = false;
            head.transform.parent = this.transform;
            head.transform.position = pos.position;
            head.transform.rotation = pos.rotation;

        }
    }
}
