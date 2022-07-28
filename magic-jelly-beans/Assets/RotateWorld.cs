using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    private int Speed1 = 20;
    private int Speed2 = 15;
    private int Speed3 = 15;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 2f * Time.deltaTime, Space.World);

        //if (Input.GetKey("w"))
        //{
        //    transform.Rotate(0, 0, -Speed1 * Time.deltaTime, Space.World);
        //}

        //if (Input.GetKey("s"))
        //{
        //    transform.Rotate(0, 0, 2f * Time.deltaTime, Space.World);
        //}

        //if (Input.GetKey("a"))
        //{
        //    transform.Rotate(2 * Time.deltaTime, 0, 0, Space.World);
        //}

        //if (Input.GetKey("d"))
        //{
        //    transform.Rotate(-Speed2 * Time.deltaTime, 0, 0, Space.World);
        //}

        //if (Input.GetKey("left"))
        //{
        //    transform.Rotate(0, Speed3 * Time.deltaTime, 0, Space.World);
        //}

        //if (Input.GetKey("right"))
        //{
        //    transform.Rotate(0, -Speed3 * Time.deltaTime, 0, Space.World);
        //}
        //}
    }
}
