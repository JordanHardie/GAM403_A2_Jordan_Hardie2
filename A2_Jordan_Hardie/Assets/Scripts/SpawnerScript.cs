using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Gem;
    GameObject Player;
    float localTimer = 0;
    int hp = 200;
    void Update()
    {
        InBounds();
    }

    void InBounds()
    {
        localTimer += Time.deltaTime;

        Player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(Player.transform);
        transform.Translate(0, 0, 2 * Time.deltaTime);

    }

    void SpawnerSpawning()
    {
        if(localTimer == 10)
        {
            Instantiate(Enemy, new Vector3(transform.position.x, 3.5f, transform.position.z), transform.rotation);
            localTimer = 0;
        }
    }
}
