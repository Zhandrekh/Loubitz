using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

	public GameObject plane;

	public GameObject hulls;
    public GameObject wings;
    public GameObject heads;
	public int selectedHull;
    public int selectedWing;
    public int selectedHead;
    public bool spawnPlane;
    public Transform spawnPos;
    public Transform headPos;
    public Transform hullPos;
    public Transform wingsPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        hulls = GetComponentInChildren<HullSelection>().hull;
        wings = GetComponentInChildren<WingsSelection>().wings;
        heads = GetComponentInChildren<HeadSelection>().head;

		if (spawnPlane) {
			spawnPlane = false;

			GameObject myPlane = Instantiate (plane, spawnPos.position, transform.rotation);

			GameObject hull = Instantiate (hulls, hullPos.position, Quaternion.identity, myPlane.transform);
			//hull.transform.localPosition = Vector3.zero;
			//hull.transform.localRotation = Quaternion.identity;

            GameObject wing = Instantiate(wings, wingsPos.position, Quaternion.identity, myPlane.transform);
            //wing.transform.localPosition = Vector3.zero;
            //wing.transform.localRotation = Quaternion.identity;

            GameObject head = Instantiate(heads, headPos.position, Quaternion.identity, myPlane.transform);
            //head.transform.localPosition = Vector3.zero;
            //head.transform.localRotation = Quaternion.identity;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        spawnPlane = true;
    }

}
