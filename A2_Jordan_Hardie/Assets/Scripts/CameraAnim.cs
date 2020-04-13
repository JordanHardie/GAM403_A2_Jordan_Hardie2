using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    private Animator animator;
    private bool inAir;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Call tilt function every frame
        tilt();
    }

    void tilt()
    {
        //Tilt's the camera on key down and then tilts it back on key release. This is aesthetic.
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("WalkingForward", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("WalkingForward", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("WalkingLeft", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("WalkingLeft", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("WalkingRight", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("WalkingRight", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("WalkingBack", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("WalkingBack", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inAir == false)
            {
                animator.SetBool("IsJumping", false);
            }

            if (inAir == true)
            {
                animator.SetBool("IsJumping", false);
            }
        }
    }
}
