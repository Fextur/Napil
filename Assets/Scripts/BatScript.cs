using UnityEngine;

public class BatScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (GameObject.Find("Master").GetComponent<GameMaster>().Lose)
        {
            pos = Vector2.MoveTowards(pos, GameObject.Find("Target").GetComponent<Transform>().position, 3f * Time.deltaTime * 50);
            transform.position = pos;
            return;
        }
        Vector3 playerPos = GameObject.Find("Pill").GetComponent<Transform>().position;
        bool puff = GameObject.Find("Pill").GetComponent<Animator>().GetBool("Puff");
        if (pos.x == 15) return;
        if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
        pos = Vector2.MoveTowards(pos, GameObject.Find("TargetPil").GetComponent<Transform>().position, 0.15f *Time.deltaTime * 50);
        if (puff) pos = Vector2.MoveTowards(pos, GameObject.Find("Target").GetComponent<Transform>().position, 2.5f * Time.deltaTime * 50);
        transform.position = pos;
        float offset = Mathf.Abs(pos.x - playerPos.x);
        if (offset < 1f)
        {
            GameObject.Find("Master").GetComponent<GameMaster>().Lose = true;
            GameObject.Find("Master").GetComponent<GameMaster>().LoseCause = "Bat";
        }
        if (pos.x < -11f || pos.x > 16) Object.Destroy(this.gameObject);
    }
}
