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

    public ParticleSystem p_head;
    ParticleSystem p_wings;
    ParticleSystem p_wings2;
    ParticleSystem p_wings3;
    ParticleSystem p_wings4;
    public ParticleSystem p_back;
    public ParticleSystem p_back2;
    ParticleSystem p_back3;

    public bool doIHaveToCharge;

    // Use this for initialization
    void Start()
    {
        //doIHaveToCharge = false;
        rb = GetComponent<Rigidbody>();
        
        p_head = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<ParticleSystem>();
        
        p_back = this.gameObject.transform.GetChild(3).GetChild(0).gameObject.GetComponent<ParticleSystem>();
        p_back2 = this.gameObject.transform.GetChild(3).GetChild(1).gameObject.GetComponent<ParticleSystem>();
        p_wings = this.gameObject.transform.GetChild(2).GetChild(0).gameObject.GetComponent<ParticleSystem>();
        p_wings2 = this.gameObject.transform.GetChild(2).GetChild(1).gameObject.GetComponent<ParticleSystem>();
        


    }

	void OnCollisionEnter(){
		if (doIHaveToCharge)
        {
            if (p_head != null)
            {
                p_head.Play();
            }
            doIHaveToCharge = false;
            Destroy(this.gameObject, 1);
        }
            
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

        
        
        if (doIHaveToCharge)
        {
            Charge();
        }

        //Charge();
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
            if (p_wings != null)
            {
                p_wings.Play();
            }
            if (p_wings2 != null)
            {
                p_wings2.Play();
            }
            if (p_back != null)
            {
                p_back.Play();
            }
            
            rb.useGravity = false;
            rb.drag = maniability;
            rb.mass = mass;
            rb.AddForce(transform.forward * speed);
            //transform.rotation = controlerRotation.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, controlerRotation.rotation, Time.deltaTime * maniability);
        }

        if (cool <= 0)
        {
            if(p_back2 != null)
            {
                p_back2.Play();
            }
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
