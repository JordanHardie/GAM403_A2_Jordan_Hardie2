using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointScript : MonoBehaviour
{
    public GameObject Gem;
    public List<float> hp = new List<float>();
    

    public void TakeDmg(int Damage, int i, GameObject wp)
    {
        hp[i] -= Damage;
        if (hp[i] <= 0)
        {
            wp.GetComponent<WeakPointManager>().kill(i);         
        }
    }
}
