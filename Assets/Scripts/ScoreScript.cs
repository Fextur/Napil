using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    Text text;
    float time;
    float next;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if (!GameObject.Find("Master").GetComponent<GameMaster>().Lose)
        {
            text.text = "" + score;
            if (next < time)
            {
                score++;
                next = time + 0.5f;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                GameObject.Find("EleTilt 1").GetComponent<AudioSource>().Play();
                GameObject.Find("Score").GetComponent<Animator>().SetBool("Instruction", true);
            }
            //else
            //{
            //
            //    text.fontSize = 50;
            //    text.text = "Score: " + score + "\n\nPress R to Restart\nPress H to save highscore\nPress I for Instructions";
            //}
        }
    }
}
