using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    Vector3 pos;
    float endX = -17.17887f;
    float deleteX = -39.27645f;
    bool next = false;
    Vector3 nextPos;
    float stopTime = 0;

    void Start()
    {
        nextPos.y = 0;
        nextPos.x = 41.20f;
    }
    
    void Update()
    {
        pos = transform.position;
        if (GameObject.Find("Master").GetComponent<GameMaster>().Lose && stopTime == 0)
        {
            stopTime = Time.time + 1f;
        }
        if (stopTime != 0)
        {
            if (stopTime < Time.time) return;
            pos.x -= (stopTime - Time.time)/10 * Time.deltaTime * 35;
            transform.position = pos;
            return;
        }
        if (pos.x <= endX && !next)
        {
            Instantiate(GameObject.Find(name), nextPos, Quaternion.identity);
            next = true;
        }
        if (pos.x <= deleteX) Object.Destroy(this.gameObject);
        pos.x -= 0.2f * Time.deltaTime * 35;
        transform.position = pos;

    }
}
