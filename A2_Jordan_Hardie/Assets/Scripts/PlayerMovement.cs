using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool isInAir;
    private Rigidbody rb;
    private float mH, mV;

    private void Start()
    {
    }

    void Update()
    {
        move();   
    }

    private void move()
    {
        //Left to right rotation of camera.
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        
        mH = Input.GetAxis("Horizontal");
        mV = Input.GetAxis("Vertical");

        
        transform.Translate(mH * speed * Time.deltaTime, 0, mV * speed * Time.deltaTime);

        if (isInAir == false)
        {
            //If the player is not in air, then they cna jump.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Makes the player jump.
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }

    //On collion with the ground, set isInAir to false.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Floor")
        {
            isInAir = false;
        }
    }

    //When the player stops colliding with the ground, update isInAir to true.
    private void OnCollisionExit(Collision collision)
    {
        isInAir = true;
    }  

    //For animator purposes.
    public bool inAir()
    {
        return isInAir;
    }
}
