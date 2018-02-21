using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float speed;
    public float acceleration;
    public float maniability;
    public float mass;
    public float cool;

    public Transform controlerRotation;
    Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();     
    }

	void OnCollisionEnter(){
		if (cool<0) 
			enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        Charge();
    }

    void Charge()
    {
        cool = cool - Time.deltaTime;

        controlerRotation = transform.parent;

        if (cool > 0)
        {
            rb.useGravity = false;
            rb.drag = 5;
            rb.AddForce(transform.forward * speed);
            //transform.rotation = controlerRotation.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, controlerRotation.rotation, Time.deltaTime * maniability);
        }

        if (cool <= 0)
        {
            rb.useGravity = true;
            rb.drag = 0;
            transform.rotation = Quaternion.LookRotation(rb.velocity.normalized, transform.up);
        }
        
    }
}
