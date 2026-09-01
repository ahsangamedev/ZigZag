using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameStarted;

    public GameObject platformSpawner;

    int score = 0;



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }


    // Start is called before the first frame update
    void Start()
    {
        
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

        StartCoroutine(UpdateScore());
    }


    public void GameOver()
    {
        platformSpawner.SetActive(false);


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

            print(score);
        }
    }


}
