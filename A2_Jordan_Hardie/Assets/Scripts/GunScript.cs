using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float rate;
    public LayerMask lm;
    public GameObject cam;
    private int gem = 0, Gem = 0;
    private float nextFire = 0;
    
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire += rate;
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, lm))
            {
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyScript>().TakeDmg(100);
                }
                
                if(hit.collider.gameObject.tag == "Weakpoint")
                {
                    hit.collider.gameObject.GetComponentInParent<EnemyScript>().TakeDmg(100);
                }
            }
        }
    }

    public void incGem()
    {
        gem++;
        Gem++;

        if(gem == 10)
        {
            rate *= 1.1f;
            gem = 0;
        }
    }

    public int gemValue()
    {
        return Gem;
    }
}
