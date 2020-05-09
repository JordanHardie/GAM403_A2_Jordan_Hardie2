using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
    }
}
