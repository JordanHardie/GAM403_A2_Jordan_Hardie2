using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 0, 5);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(0, 0, -5);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 0, -5);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(0, 0, 5);
        }
    }
}
