using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HighscoresScript : MonoBehaviour
{
    public int score;
    public string name;
    int spot = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<FinalScoreScript>().finalScore;
        //ResetHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        ShowHighScores();
        if (spot != -1)
            SetNewHighscore();
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    //Shows the high scores
    void ShowHighScores()
    {
        GameObject.Find("Num1").GetComponent<Text>().text = "" + PlayerPrefs.GetString("number1", "Empty");
        GameObject.Find("Num2").GetComponent<Text>().text = "" + PlayerPrefs.GetString("number2", "Empty");
        GameObject.Find("Num3").GetComponent<Text>().text = "" + PlayerPrefs.GetString("number3", "Empty");
        GameObject.Find("Num4").GetComponent<Text>().text = "" + PlayerPrefs.GetString("number4", "Empty");
        GameObject.Find("Num5").GetComponent<Text>().text = "" + PlayerPrefs.GetString("number5", "Empty");
    }

    //Resets the highscores
    void SetHighScores()
    {
        //Set all the playerPrefs int to 0 and strings to "nobody - 0"
        PlayerPrefs.SetInt("score1", 50);
        PlayerPrefs.SetString("number1", "a - " + PlayerPrefs.GetInt("score1"));
        PlayerPrefs.SetInt("score2", 40);
        PlayerPrefs.SetString("number2", "b - " + PlayerPrefs.GetInt("score2"));
        PlayerPrefs.SetInt("score3", 30);
        PlayerPrefs.SetString("number3", "c - " + PlayerPrefs.GetInt("score3"));
        PlayerPrefs.SetInt("score4", 20);
        PlayerPrefs.SetString("number4", "d - " + PlayerPrefs.GetInt("score4"));
        PlayerPrefs.SetInt("score5", 10);
        PlayerPrefs.SetString("number5", "e - " + PlayerPrefs.GetInt("score5"));
    }

    void ResetHighScores()
    {
        PlayerPrefs.DeleteKey("score1");
        PlayerPrefs.DeleteKey("score2");
        PlayerPrefs.DeleteKey("score3");
        PlayerPrefs.DeleteKey("score4");
        PlayerPrefs.DeleteKey("score5");

        PlayerPrefs.DeleteKey("number1");
        PlayerPrefs.DeleteKey("number2");
        PlayerPrefs.DeleteKey("number3");
        PlayerPrefs.DeleteKey("number4");
        PlayerPrefs.DeleteKey("number5");
    }

    void SetNewHighscore()
    {
        int peepee = score;
        int temp;
        string tempName;
        if (spot != 0)
        {
            name = GameObject.Find("Name").GetComponent<Text>().text + " - " + score;
            if (spot == 1) PlayerPrefs.SetString("number1", name);
            if (spot == 2) PlayerPrefs.SetString("number2", name);
            if (spot == 3) PlayerPrefs.SetString("number3", name);
            if (spot == 4) PlayerPrefs.SetString("number4", name);
            if (spot == 5) PlayerPrefs.SetString("number5", name);
            return;

        }
        if (peepee > PlayerPrefs.GetInt("score1", 0))
        {
            temp = PlayerPrefs.GetInt("score1", 0);
            PlayerPrefs.SetInt("score1", peepee);
            tempName = PlayerPrefs.GetString("number1", "Empty");
            PlayerPrefs.SetString("number1", name);
            peepee = temp;
            name = tempName;
            if (spot == 0) spot = 1;
        }

        if (peepee > PlayerPrefs.GetInt("score2", 0) || spot != 0)
        {
            temp = PlayerPrefs.GetInt("score2", 0);
            PlayerPrefs.SetInt("score2", peepee);
            tempName = PlayerPrefs.GetString("number2", "Empty");
            PlayerPrefs.SetString("number2", name);
            peepee = temp;
            name = tempName;
            if (spot == 0) spot = 2;
        }
        if (peepee > PlayerPrefs.GetInt("score3", 0) || spot != 0)
        {
            temp = PlayerPrefs.GetInt("score3", 0);
            PlayerPrefs.SetInt("score3", peepee);
            tempName = PlayerPrefs.GetString("number3", "Empty");
            PlayerPrefs.SetString("number3", name);
            peepee = temp;
            name = tempName;
            if (spot == 0) spot = 3;
        }
        if (peepee > PlayerPrefs.GetInt("score4", 0) || spot != 0)
        {
            temp = PlayerPrefs.GetInt("score4", 0);
            PlayerPrefs.SetInt("score4", peepee);
            tempName = PlayerPrefs.GetString("number4", "Empty");
            PlayerPrefs.SetString("number4", name);
            peepee = temp;
            name = tempName;
            if (spot == 0) spot = 4;
        }
        if (peepee > PlayerPrefs.GetInt("score5") || spot != 0)
        {
            PlayerPrefs.SetInt("score5", peepee);
            PlayerPrefs.SetString("number5", name);
            if (spot == 0) spot = 5;
            return;
        }
        spot = -1;
    }

}
