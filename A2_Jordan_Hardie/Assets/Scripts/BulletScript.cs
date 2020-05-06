using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float lifetime = 6;
    private Rigidbody rb;

    private void Start()
    {
        //Grab the rigidbody.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Bullet goes forward instantly.
        rb.AddForce(transform.forward * 50 * Time.deltaTime, ForceMode.VelocityChange);

        //Make it spin.
        transform.Rotate(0, 0, 45 * Time.deltaTime);

        //Make it so that eventually the bullet goes away.
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Just to make sure it's hitting what I want it to.
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Weakpoint")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyScript>().TakeDmg(100);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Weakpoint")
            {
                GameObject weakpoint = collision.gameObject;
                int i = collision.gameObject.GetComponent<WeakPointManager>().returnIndex();
                collision.gameObject.GetComponentInParent<WeakPointScript>().TakeDmg(100, i, weakpoint);
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
