using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Update()
    {
        tilt();
    }

    void tilt()
    {
        transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);

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
