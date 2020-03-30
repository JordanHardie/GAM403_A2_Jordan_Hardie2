using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Declaration of varibles.
    //Public so the healh can be different with each enemy.
    public int hp;
    //Same with speed.
    public float speed;
    //A reference to a prefab and a enemy for spawner script.
    public GameObject Gem, Enemy;
    //Player is private to make my life harder.
    private GameObject Player;
    //Timer for spawner enemies.
    private float localTimer = 0;

    void Update()
    {
        //Move and spawners spawn.
        movement();
        SpawnerSpawning();
    }

    void movement()
    {
        //Look for a game object with the tag of palyer.
        Player = GameObject.FindGameObjectWithTag("Player");
        //Look at that son of a gun.
        transform.LookAt(Player.transform);
        //Ho boy, now the enemy moves along the z axis.
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    
    //Public so other scripts can access it.
    public void TakeDmg(int Damage)
    {
        //hp = hp - damage, so enemies can die.
        hp -= Damage;
        
        //See if the enemy is dead.
        if (hp <= 0)
        {
            //Spawn in the gem prefab at the transform position, it needed rotation otherwise it would not work.
            Instantiate(Gem, new Vector3(transform.position.x, 1.5f, transform.position.z), transform.rotation);
            //Destroy the game object this script is attached to.
            Destroy(gameObject);
        }
    }
    
    //Spawner enemy function.
    void SpawnerSpawning()
    {
        //If the game object is tagged as a spawner.
        if(gameObject.tag == "Spawner")
        {
            //Simple timer
            localTimer += Time.deltaTime;
            
            //Every 10 seconds do the following.
            if (localTimer >= 10)
            {
                //Spawn in the enemy as the spawners position above it.
                Instantiate(Enemy, new Vector3(transform.position.x, 3.5f, transform.position.z), transform.rotation);
                //Reset the timer.
                localTimer = 0;
            }
        }      
    }
}
