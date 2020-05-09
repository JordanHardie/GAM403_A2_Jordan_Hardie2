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
    public float speed, spawnRate;
    //A reference to a prefab and a enemy for spawner script.
    public GameObject Gem;
    //For if there more than one enemy I want to spawn
    public List<GameObject> Enemy = new List<GameObject>();
    //Simple public bool to tell the script its a different type of enemy.
    public bool isEnemyTwo;
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
        if (isEnemyTwo == false)
        {
            //Look for a game object with the tag of palyer.
            Player = GameObject.FindGameObjectWithTag("Player");
            //Look at that son of a gun.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Player.transform.position - transform.position), 0.5f);
            //Ho boy, now the enemy moves along the z axis.
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        
        if(isEnemyTwo == true)
        {
            //Look for a game object with the tag of palyer.
            Player = GameObject.FindGameObjectWithTag("Player");
            //Look at that son of a gun.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Player.transform.position - transform.position), 0.09f);
            //Ho boy, now the enemy moves along the z axis.
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
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
            if (gameObject.tag == "Spawner" || gameObject.tag == "SpawnerTwo")
            {
                Destroy(gameObject);
            }

            else
            {
                Instantiate(Gem, new Vector3(transform.position.x, 1.5f, transform.position.z), transform.rotation);
                //Destroy the game object this script is attached to.
                Destroy(gameObject);
            }     
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
            
            //Every time local timer is great than spawnrate do the following.
            if (localTimer >= spawnRate)
            {
                //Spawn in the enemy as the spawners position above it.
                Instantiate(Enemy[0], new Vector3(transform.position.x, 3.5f, transform.position.z), transform.rotation);
                //Reset the timer.
                localTimer = 0;
            }
        }
        
        if(gameObject.tag == "SpawnerTwo")
        {
            //Simple timer
            localTimer += Time.deltaTime;

            //Every 10 seconds do the following.
            if (localTimer >= spawnRate)
            {
                //Spawn in the enemy as the spawners position above it.
                Instantiate(Enemy[0], new Vector3(transform.position.x, 3.5f, transform.position.z), transform.rotation);
                Instantiate(Enemy[1], new Vector3(transform.position.x, 3.5f, transform.position.z), transform.rotation);
                //Reset the timer.
                localTimer = 0;
            }
        }
    }
}
