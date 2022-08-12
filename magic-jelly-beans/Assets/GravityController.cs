using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    public GravityOrbit gravityOrbit;
    private Rigidbody rb;

    public float rotationSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gravityOrbit)
        {
            Vector3 gravityUp = Vector3.zero;
            gravityUp = (transform.position - gravityOrbit.transform.position).normalized;

            Vector3 localUp = transform.up;

            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            rb.GetComponent<Rigidbody>().rotation = targetRotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.GetComponent<Rigidbody>().AddForce((-gravityUp * gravityOrbit.gravity) * rb.mass);
        }
    }
}
