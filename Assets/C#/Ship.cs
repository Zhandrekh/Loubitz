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

    Transform y;
    Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        y = transform;
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
            rb.AddForce(transform.forward * speed);
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (cool <= 0)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        
    }
}
