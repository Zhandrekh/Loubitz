using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

	public GameObject plane;

	public GameObject hulls;
    public GameObject wings;
    public GameObject heads;
    public GameObject backs;
	public int selectedHull;
    public int selectedWing;
    public int selectedHead;
    public bool spawnPlane;
    public Transform spawnPos;
    public Transform headPos;
    public Transform hullPos;
    public Transform wingsPos;
    public Transform backPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        hulls = GetComponentInChildren<HullSelection>().refHull;
        wings = GetComponentInChildren<WingsSelection>().refWings;
        heads = GetComponentInChildren<HeadSelection>().refHead;
        backs = GetComponentInChildren<BackSelection>().refBack;

		if (spawnPlane) {
			spawnPlane = false;
            
			GameObject myPlane = Instantiate (plane, spawnPos.position, spawnPos.rotation);

            GameObject head = Instantiate(heads, headPos.position, headPos.rotation, myPlane.transform);
            GameObject hull = Instantiate (hulls, hullPos.position, hullPos.rotation, myPlane.transform);			
            GameObject wing = Instantiate(wings, wingsPos.position, wingsPos.rotation, myPlane.transform);           
            GameObject back = Instantiate(backs, backPos.position, backPos.rotation, myPlane.transform);
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Controller") spawnPlane = true;
    }

}
