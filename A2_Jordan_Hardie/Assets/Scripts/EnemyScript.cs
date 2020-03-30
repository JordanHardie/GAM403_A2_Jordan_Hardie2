using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp;
    public float speed;
    public GameObject Gem, Enemy;
    private GameObject Player;
    private float localTimer = 0;

    void Update()
    {
        movement();
        SpawnerSpawning();
    }

    void movement()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(Player.transform);
        transform.Translate(0, 0, 2f * Time.deltaTime);
    }

    public void TakeDmg(int Damage)
    {
        hp -= Damage;

        if (hp <= 0)
        {
            Instantiate(Gem, new Vector3(transform.position.x, 1.5f, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }

    void SpawnerSpawning()
    {
        if(gameObject.tag == "Spawner")
        {
            localTimer += Time.deltaTime;

            if (localTimer >= 10)
            {
                Instantiate(Enemy, new Vector3(transform.position.x, 3.5f, transform.position.z), transform.rotation);
                localTimer = 0;
            }
        }      
    }
}
