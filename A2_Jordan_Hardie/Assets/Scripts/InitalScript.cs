using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitalScript : MonoBehaviour
{
    public void StartGame()
    {
        Init();
    }

    void Init()
    {
        SceneManager.LoadScene("GameScene");
    }
}
