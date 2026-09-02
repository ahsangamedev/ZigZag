using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameStarted;

    public GameObject platformSpawner;

    public GameObject menuUi;

    public Text scoreText;
    public Text highScoreText;





    AudioSource audioSource; // storing the audio source
    public AudioClip[] gameMusic;



    public GameObject gamePlayUI;

    int score = 0;
    int highScore;



    void Awake()
    {   
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();    
    }


    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {

            if (Input.GetMouseButton(0))
            {
                GameStart();
            }
        }
    }


    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        menuUi.SetActive(false);
        gamePlayUI.SetActive(true);
        //play audio
        audioSource.clip = gameMusic[1];
        audioSource.Play();

        StartCoroutine("UpdateScore");
    }


    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SavedHighScore();

        

        Invoke("ReloadLevel", 1f);
    }




    void ReloadLevel()
    {
       SceneManager.LoadScene("Game"); 
    }




    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            score ++;
            
            scoreText.text = score.ToString();

            // print(score);
        }
    }



    public void IncermentScore()
    {
        score += 2;     //score = score + 2;

        audioSource.PlayOneShot(gameMusic[2], 0.2f);
    }



    void SavedHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // we already have a high score

            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

        }
        else
        {
            // playing for the first time we dont have a high score then 

            PlayerPrefs.SetInt("HighScore", score);
        }


    }


}
