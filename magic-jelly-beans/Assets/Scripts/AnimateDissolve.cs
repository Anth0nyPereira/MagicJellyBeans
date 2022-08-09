using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDissolve : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("makeDissolve");
        }
        
        

    }
}
