using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    float stopTime = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (GameObject.Find("Master").GetComponent<GameMaster>().Lose && stopTime == 0)
        {
            stopTime = Time.time + 1.5f;
            GetComponent<Animator>().SetBool("Lose", true);
        }
        if (Time.time > stopTime) return;
        if (stopTime != 0)
        {
            GetComponent<Animator>().speed = (stopTime - Time.time) / 1.5f;
            Vector3 pos = transform.position;
            pos.x += ((stopTime - Time.time) / 1.5f) * Time.deltaTime * 20;
            transform.position = pos;
        }
    }
}
