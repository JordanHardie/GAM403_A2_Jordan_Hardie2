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
    private float nextFire = 0;
    
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        //If clickity click and time is greater than next fire.
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            Ray ray = new Ray(transform.position, cam.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
            }

            Instantiate(bullet, transform.position, Quaternion.LookRotation(ray.direction));
        }
    }

    public void incGem()
    {
        //Increase gem values by one
        gem++;
        Gem++;

        if(gem == 10)
        {
            //if its equal to 10 icnrease fire rate by 10%
            rate *= 1.1f;
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
