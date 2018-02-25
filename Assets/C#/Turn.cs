using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

    public float speed;
    public float lerpSpeed;
    public bool x;
    public bool y;
    public bool z;
    float target=1;
    Quaternion targetRot;

    private void Start()
    {
        target = target * speed;

        if (x)
        {
            targetRot = new Quaternion(target, transform.rotation.y, transform.rotation.z, Quaternion.identity.w);
        }
        if (y)
        {
            targetRot = new Quaternion(transform.rotation.x, target, transform.rotation.z, Quaternion.identity.w);
        }
        if (z)
        {
            targetRot = new Quaternion(transform.rotation.x, transform.rotation.y, target, Quaternion.identity.w);
        }
    }

    // Update is called once per frame
    void Update () {
        target += target;

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, lerpSpeed);
	}
}
