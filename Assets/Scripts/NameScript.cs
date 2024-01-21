using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameScript : MonoBehaviour
{
    Text player;
    void Start()
    {
        player = GetComponent<Text>();
        player.text = "";
    }
    
    void Update()
    {
        if (!Input.anyKeyDown) return;
        string c = Input.inputString;
        GameObject.Find("Tick").GetComponent<AudioSource>().Play();
        if (c == "\b")
        {
            if (player.text.Length != 0)
            {
                player.text = player.text.Substring(0, player.text.Length - 1);
            }
        }
        else if (player.text.Length < 16 && !((c == "\n") || (c == "\r")))
            player.text += c;
        //GameObject.Find("Highscores").GetComponent<HighscoresScript>().name = player.text + " - " + GameObject.Find("Highscores").GetComponent<HighscoresScript>().score;
    }
}
