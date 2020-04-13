﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float lifetime = 6;
    void Update()
    {
        transform.Translate(0, 0, 5 * Time.deltaTime);
        transform.Rotate(0, 0, 45 * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Weakpoint")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyScript>().TakeDmg(100);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Weakpoint")
            {
                collision.gameObject.GetComponentInParent<EnemyScript>().TakeDmg(100);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
