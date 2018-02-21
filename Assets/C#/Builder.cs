using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

	public GameObject plane;

	public GameObject[] hulls;
    public GameObject[] wings;
    public GameObject[] heads;
	public int selectedHull;
    public int selectedWing;
    public int selectedHead;
    public bool spawnPlane;
    public Transform spawnPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnPlane) {
			spawnPlane = false;

			GameObject myPlane = Instantiate (plane, spawnPos.position, transform.rotation);

			GameObject hull = Instantiate (hulls [selectedHull], myPlane.transform);
			//hull.transform.localPosition = Vector3.zero;
			//hull.transform.localRotation = Quaternion.identity;

            GameObject wing = Instantiate(wings[selectedWing], myPlane.transform);
            //wing.transform.localPosition = Vector3.zero;
            //wing.transform.localRotation = Quaternion.identity;

            GameObject head = Instantiate(heads[selectedHead], myPlane.transform);
            //head.transform.localPosition = Vector3.zero;
            //head.transform.localRotation = Quaternion.identity;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        spawnPlane = true;
    }

}
