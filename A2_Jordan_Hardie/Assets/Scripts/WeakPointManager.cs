using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointManager : MonoBehaviour
{
    public GameObject Gem;
    public int index;

    public int returnIndex()
    {
        return index;
    }

    public void kill(int check)
    {
        if (check == index)
        {
            //Spawn in the gem prefab at the transform position, it needed rotation otherwise it would not work.
            Instantiate(Gem, new Vector3(transform.position.x, 1.5f, transform.position.z), transform.rotation);

            //Destroy the game object this script is attached to.
            Destroy(gameObject);
        }
    }
}
