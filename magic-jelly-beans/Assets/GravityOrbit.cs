using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float gravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravityController>())
        {
            other.GetComponent<GravityController>().gravityOrbit = this.GetComponent<GravityOrbit>();
        }
    }
}
