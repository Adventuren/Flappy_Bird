using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameEnded;
    public float Gametime;


    private void Start()
    {
        GameEnded = false;
       Gametime = Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameEnded == true)
        {

            SceneManager.LoadScene("SampleScene");

        }

        if (Input.GetKeyDown(KeyCode.Q) && GameEnded == true)
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {


        GameEnded = true;
    }


    public void Build()
    {

    }
}