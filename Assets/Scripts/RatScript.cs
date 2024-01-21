using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 playerPos = GameObject.Find("Pill").GetComponent<Transform>().position;
        if (GameObject.Find("Master").GetComponent<GameMaster>().Lose && pos.x > playerPos.x)
        {
            pos = Vector2.MoveTowards(pos, GameObject.Find("Target").GetComponent<Transform>().position, 3f * Time.deltaTime * 50);
            transform.position = pos;
            return;
        }
        int jump = GameObject.Find("Pill").GetComponent<PillScript>().jump;
        if (pos.x == 15) return;
        if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
        pos.x -= 0.2f * Time.deltaTime * 50;
        float offset = Mathf.Abs(pos.x - playerPos.x);
        if (offset < 4f)
        {
            pos.y += (pos.x - playerPos.x) * Time.deltaTime;
            GetComponent<Animator>().SetBool("Jump", true);
        }
        else GetComponent<Animator>().SetBool("Jump", false);


        transform.position = pos;
        if (jump == 0 && offset < 0.5f)
        {
            GameObject.Find("Master").GetComponent<GameMaster>().Lose = true;
            GameObject.Find("Master").GetComponent<GameMaster>().LoseCause = "Rat";
        }
        if (pos.x < -11f) Object.Destroy(this.gameObject);
    }
}
