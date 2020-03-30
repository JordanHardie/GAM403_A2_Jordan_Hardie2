using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 20 * Time.deltaTime, 20 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Player")
        {
            collision.collider.GetComponentInChildren<GunScript>().incGem();
            Destroy(gameObject);
        }
    }
}
