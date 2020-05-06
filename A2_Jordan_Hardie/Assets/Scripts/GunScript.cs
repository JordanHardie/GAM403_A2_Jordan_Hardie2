using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    //Declaration of varibles.
    //Public so I could test fire-rates
    public float rate;
    //Layermask for enemies
    public LayerMask lm;
    //A reference to the camera
    public GameObject cam, bullet;
    //Gem values placeholders. Why two? Because.
    private int gem = 0, Gem = 0;
    //To make the fire rate actually work
    private float nextFire = -1f;
    
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        //If next fire is greater than zero
        if (nextFire > 0)
        {
            //Basic timer for nextFire
            nextFire -= Time.deltaTime;
            return;
        }

        //Else if the user clicks.
        else if (Input.GetMouseButton(0))
        {
            //Creates ray from the gun position, towards the forward of the camera, so the recticule is correct.
            Ray ray = new Ray(transform.position, cam.transform.forward);

            //Unused but hit information just so the raycast actually works.
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
            }

            //The raycast creates a path for the bullet to follow.
            Instantiate(bullet, transform.position, Quaternion.LookRotation(ray.direction));

            //Reset nextFire
            nextFire = rate;
        }
    }

    public void incGem()
    {
        //Increase gem values by one
        gem++;
        Gem++;

        if(gem == 10)
        {
            //if its equal to 10 increase fire rate by 10%
            rate /= 1.1f;
            print("Increased fire rate by 10%");
            //Reset the count to zero, this is why I need two, one for display on UI, one for function.
            gem = 0;
        }
    }
    
    //Possibly the best function of all time. Just returns the value of Gem.
    public int gemValue()
    {
        return Gem;
    }
}
