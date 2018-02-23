using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float speed;
    public float maniability;
    public float mass;
    public float cool;

    float wSpeed;
    float wMania;
    float wMass;

    float hSpeed;
    float hMania;
    float hMass;

    float hdSpeed;
    float hdMania;
    float hdMass;

    float bSpeed;
    float bMania;
    float bMass;

    public Transform controlerRotation;
    Rigidbody rb;
    bool doIHaveToCharge = false;

    // Use this for initialization
    void Start()
    {
        doIHaveToCharge = false;
        rb = GetComponent<Rigidbody>();     
    }

	void OnCollisionEnter(){
		if (cool<0) 
			enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        WingsStat wing = GetComponentInChildren<WingsStat>();
        if (wing != null)
        {
            wSpeed = wing.wingSpeed;
            wMania = wing.wingMania;
            wMass = wing.wingMass;
        }

        HullsStat hull = GetComponentInChildren<HullsStat>();
        if (hull != null)
        {
            hSpeed = hull.hullSpeed;
            hMania = hull.hullMania;
            hMass = hull.hullMass;
        }

        HeadsStat head = GetComponentInChildren<HeadsStat>();
        if (head != null)
        {
            hdSpeed = head.headSpeed;
            hdMania = head.headMania;
            hdMass = head.headMass;
        }

        BacksStat back = GetComponentInChildren<BacksStat>();
        if (back != null)
        {
            bSpeed = back.backSpeed;
            bMania = back.backMania;
            bMass = back.backMass;
        }

        speed = wSpeed + hSpeed + hdSpeed + bSpeed;
        maniability = wMania + hMania + hdMania + bMania;
        mass = wMass + hMass + hdMass + bMass;

        rb.drag = maniability;
        rb.mass = mass;
        if (doIHaveToCharge)
        {
            Charge();
        }
    }

    public void GoCharge()
    {
        doIHaveToCharge = true;
    }
    public void Charge()
    {
        cool = cool - Time.deltaTime;

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

    public void FindControl()
    {
        controlerRotation = transform.parent;
    }
}
