using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointScript : MonoBehaviour
{
    public GameObject Gem;
    public List<float> hp = new List<float>();
    public int health;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDmg(int Damage, int i, GameObject wp)
    {
        hp[i] -= Damage;
        if (hp[i] <= 0)
        {
            health -= 500;
            wp.GetComponent<WeakPointManager>().kill(i);         
        }
    }
}
