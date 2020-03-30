using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    void Update()
    {
        //Frame rate independant spinning animation.
        transform.Rotate(20 * Time.deltaTime, 20 * Time.deltaTime, 20 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the gem runs into the player.
        if(collision.collider.gameObject.name == "Player")
        {
            //Why didn't I just put the incGem function in the player movement script?
            //The amount of gem's the player has increases the gun fire rate.
            collision.collider.GetComponentInChildren<GunScript>().incGem();
            //Destroy the gem.
            Destroy(gameObject);
        }
    }
}
