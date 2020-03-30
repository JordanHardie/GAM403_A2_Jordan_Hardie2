using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Logic : MonoBehaviour
{
    public Text timerText, deathText, gemText;
    public GameObject Gun, Spawner;
    private string saved;
    private float seconds = 0, countdown = 20, x, z;
    private int minutes = 0; 

    void Start()
    {
        deathText.gameObject.SetActive(false);
    }

    void Update()
    {
        timer();
    }

    void timer()
    {
        countdown -= Time.deltaTime;
        seconds += Time.deltaTime;

        timerText.text = minutes + ":" + seconds;

        gemText.text = "Gem Count: " + Gun.GetComponent<GunScript>().gemValue();

        if (seconds >= 60)
        {
            minutes += 1;
            seconds = 0;
        }

        if (countdown <= 0)
        {
            SpawnerSpawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "SubFloor" || collision.collider.gameObject.tag == "Enemy")
        {
            saved = minutes + ":" + seconds;

            deathText.gameObject.SetActive(true);

            deathText.text = "You Died! Time survived: " + saved;

            Time.timeScale = 0;
        }
    }

    private void SpawnerSpawn()
    {
        countdown = Random.Range(20, 25);

        float flip = Random.Range(1, 2);

        if(flip > 0)
        {
            x = Random.Range(25, 35);
            float Flip = Random.Range(1, 2);

            if(Flip > 0)
            {
                z = Random.Range(25, 35);
            }

            else if(Flip <= 0)
            {
                z = Random.Range(-25, -35);
            }
        }

        else if(flip <= 0)
        {
            x = Random.Range(-25, -35);
            float Flip = Random.Range(1, 2);

            if(Flip > 0)
            {
                z = Random.Range(25, 35);
            }

            else if(Flip <= 0)
            {
                z = Random.Range(-25, 35);
            }
        }

        Instantiate(Spawner, new Vector3(x, 1.5f, z), new Quaternion(0, 0, 0, 0));
    }
}
