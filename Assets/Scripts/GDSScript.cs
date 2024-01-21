using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GDSScript : MonoBehaviour
{
    public int score = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            score = GameObject.Find("Points").GetComponent<ScoreScript>().score;
            if (PlayerPrefs.GetInt("score1", 0) < score && GameObject.Find("Score").GetComponent<Animator>().GetBool("Lose"))
            {
                GameObject.Find("Score").GetComponent<Animator>().SetBool("Highscore", true);
            }
            else if (PlayerPrefs.GetInt("score5", 0) < score && GameObject.Find("Score").GetComponent<Animator>().GetBool("Lose"))
            {
                GameObject.Find("Score").GetComponent<Animator>().SetBool("Top5", true);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
