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
    public GameObject cam;
    //Gem values placeholders. Why two? Because.
    private int gem = 0, Gem = 0;
    //To make the fire rate actually work
    private float nextFire = 0;
    
    void Update()
    {
        //Shoot the kids.
        //Hang the Family.
        //Frame them all.
        shoot();
    }

    void shoot()
    {
        //If clickity click and time is greater than next fire.
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            //Add rate to next fire
            nextFire += rate;
            //Make a new ray call it ray and its from the camera and goes forward.
            //This is sothat the reticule makes sense.
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            //What the raycast hit
            RaycastHit hit;
            //if laser beam hits something within 100 units and its an enemy.
            if (Physics.Raycast(ray, out hit, 100, lm))
            {
                //See if its an Enemy.
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    //Do 100 damage to the enemy.
                    hit.collider.gameObject.GetComponent<EnemyScript>().TakeDmg(100);
                }
                
                //See if its the weakpoint of the spawner.
                if(hit.collider.gameObject.tag == "Weakpoint")
                {
                    //The weakpoint itself doesn't have the enemy script, but the swpaner parent its attached to does.
                    //This is because if I tried to attach the script to the weakpoint, it would make its seperate health.
                    hit.collider.gameObject.GetComponentInParent<EnemyScript>().TakeDmg(100);
                }
            }
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
