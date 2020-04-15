using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool isInAir;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

        if (isInAir == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Floor")
        {
            isInAir = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isInAir = true;
    }  

    public bool inAir()
    {
        return isInAir;
    }
}
