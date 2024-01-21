using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour
{
    public int finalScore;
    int currScore = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        finalScore = GameObject.Find("GDS").GetComponent<GDSScript>().score;
    }

    // Update is called once per frame
    void Update()
    {
        if (currScore < finalScore - 1000) currScore += 1000;
        else if (currScore < finalScore - 100) currScore += 100;
        else if (currScore < finalScore - 10) currScore += 10;
        else if (currScore < finalScore) currScore++;
        score.text = "" + currScore;
    }
}
