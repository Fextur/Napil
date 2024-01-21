using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    float time;
    float nextRat = 0;
    Vector3 RatStartPos;
    float maxRat = 7f;
    float minRat = 5f;
    float absoluteMinRat = 1f;
    float absoluteMaxRat = 3f;


    float nextBat = 0;
    Vector3 BatStartPos;
    float maxBat = 15f;
    float minBat = 10f;
    float absoluteMinBat = 3f;
    float absoluteMaxBat = 5f;

    public bool Lose = false;
    public string LoseCause;

    bool HSPlayed = false;
    bool T5Played = false;


    void Start()
    {
        RatStartPos.y = -1.61f;
        RatStartPos.x = 11.39f;


        BatStartPos.y = 2.05f;
        BatStartPos.x = 11.39f;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;

        if (Lose)
        {
            Losing();
            return;
        }
        Rat();
        Bat();
    }

    void Rat()
    {
        if (nextRat == 0) nextRat = time + Random.Range(minRat, maxRat + 1);
        //if (nextRat == 0) nextRat = time + 3f;
        if (nextRat < time)
        {
            Instantiate(GameObject.Find("Rat"), RatStartPos, Quaternion.identity);
            nextRat = time + Random.Range(minRat, maxRat + 1);
            //nextRat = time + 3f;
        }
        if (minRat > absoluteMinRat) minRat -= 0.001f;
        if (maxRat > absoluteMaxRat) maxRat -= 0.005f;
    }

    void Bat()
    {
        if (nextBat == 0) nextBat = time + Random.Range(minBat, maxBat + 1);
        if (nextBat < time)
        {
            Instantiate(GameObject.Find("Bat"), BatStartPos, Quaternion.identity);
            nextBat = time + Random.Range(minBat, maxBat + 1);
        }
        if (minBat > absoluteMinBat) minBat -= 0.1f;
        if (maxBat > absoluteMaxBat) maxBat -= 0.1f;
    }

    void Losing()
    {
        if (LoseCause == "Bat" || LoseCause == "Rat")
        {
            GameObject.Find("Pill").GetComponent<Animator>().SetInteger("Tilt", -3);
        }
        if (GameObject.Find("Score").GetComponent<Animator>().GetBool("Highscore"))
        {
            if (!HSPlayed)
            {
                GameObject.Find("NewHS").GetComponent<AudioSource>().Play();
                HSPlayed = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("HighscoreScene");
            }
        }
        else if (GameObject.Find("Score").GetComponent<Animator>().GetBool("Top5"))
        {
            if (!T5Played)
            {
                GameObject.Find("Top5").GetComponent<AudioSource>().Play();
                T5Played = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("HighscoreScene");
            }
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("MainScene");
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("HighscoreScene");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("MainScene");
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("HighscoreScene");
            }
        }
        GameObject.Find("Soundtrack").GetComponent<AudioSource>().volume = 0.03f;
        GameObject.Find("Puffer").GetComponent<AudioSource>().Stop();
        GameObject.Find("Score").GetComponent<Animator>().SetBool("Lose", true);
    }
}
