using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;

    public int hazardCount =10; // total de asteroid por wave

    public float spawnWait, waveWait, startWait;
    
    //To Controler UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;  

    int score;
    Boolean gameOver,restart;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score=0;
        WriteScore();
        gameOver=false;
        restart =false;
        StartCoroutine(SpawnWaves());


    }

    IEnumerator SpawnWaves()
    {
        yield  return  new WaitForSeconds(startWait);
        while (!gameOver)
        {
             for (int i=0; i<hazardCount && !gameOver; i++)
               {
                    Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard,spawnPosition, spawnRotation);
                    yield  return  new WaitForSeconds(spawnWait);
               }

             


              if (!gameOver)
                 {
                   yield  return  new WaitForSeconds(waveWait);  
                  
                 }
        }

                 restartText.text= "Press <R> to restart";
                 restart = true;
                   
    }



    public void AddScore()
    {
        score = score + 10;
        WriteScore();
    }
    void WriteScore()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void GameOver()
    {
        gameOver= true;
        gameOverText.text = "Game Over";

    }
    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
