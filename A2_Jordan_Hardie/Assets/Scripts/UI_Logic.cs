using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Logic : MonoBehaviour
{
    public Text timerText, deathText, gemText, restartText;
    public GameObject Gun, Spawner, Floor;
    private string saved;
    private float seconds = 0, countdown = 0;
    private float fixedCountdown = 20;
    private int x, z;

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
        if(seconds % 50 == 0)
        {
            fixedCountdown /= 1.001f;           
        }

        if(seconds % 200 == 0)
        {
            Floor.transform.localScale /= 1.01f;
        }

        countdown -= Time.deltaTime;
        seconds += Time.deltaTime;

        timerText.text = seconds.ToString();

        gemText.text = "Gem Count: " + Gun.GetComponent<GunScript>().gemValue();

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

            saved = seconds.ToString();
            deathText.text = "You Died! Time survived: " + saved;

            Time.timeScale = 0;

            restartText.gameObject.SetActive(true);
        }
    }

    private void SpawnerSpawn()
    {
        countdown = fixedCountdown;

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
