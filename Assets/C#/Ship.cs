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

    // Update is called once per frame
    void Update()
    {
        Charge();
    }

    void Charge()
    {
        cool = cool - Time.deltaTime;
        if (cool > 0)
        {
            rb.useGravity = false;
            rb.AddForce(transform.forward * speed);
            //transform.rotation = controlerRotation.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, controlerRotation.rotation, Time.deltaTime * maniability);
        }

        if (cool <= 0)
        {
            rb.useGravity = true;
            transform.rotation = transform.rotation;
        }
        
    }
}
