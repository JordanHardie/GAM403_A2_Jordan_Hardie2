using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Animator animator;

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
        //Rotate the camera around the x axis by the negative of the mouse y movement.
        transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        
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
            
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            
        }
    }
}
