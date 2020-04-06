using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Logic : MonoBehaviour
{
    public Text timerText, deathText, gemText, restartText;
    public GameObject Gun, Spawner;
    private string saved;
    private float seconds = 0, countdown = 5;
    private int minutes = 0, x, z;

    void Start()
    {
        deathText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        Cursor.visible = false;
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
            Instantiate(Spawner, new Vector3(x, 1.5f, z), new Quaternion(0, 0, 0, 0));
        }

        if(restartText.IsActive() == true)
        {
            restartText.text = "Press R or enter to restart.";
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "SubFloor" || collision.collider.gameObject.tag == "Enemy")
        {
            deathText.gameObject.SetActive(true);

            saved = minutes + ":" + seconds;
            deathText.text = "You Died! Time survived: " + saved;

            Time.timeScale = 0;

            restartText.gameObject.SetActive(true);
        }
    }

    private void SpawnerSpawn()
    {
        countdown = Random.Range(10, 15);

        float flip = Random.Range(1, 3);

        if(flip == 1)
        {
            x = Random.Range(25, 35);
            float Flip = Random.Range(1, 3);

            if(Flip == 1)
            {
                z = Random.Range(25, 35);
            }

            else if(Flip == 2)
            {
                z = Random.Range(-25, -35);
            }
        }

        else if(flip == 2)
        {
            x = Random.Range(-25, -35);
            float Flip = Random.Range(1, 3);

            if(Flip == 1)
            {
                z = Random.Range(25, 35);
            }

            else if(Flip == 2)
            {
                z = Random.Range(-25, 35);
            }
        }
    }
}
