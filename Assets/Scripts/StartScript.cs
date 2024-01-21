using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            GameObject.Find("EleTilt").GetComponent<AudioSource>().Play();
            if (anim.GetBool("Space"))
                SceneManager.LoadScene("MainScene");
            else
            {
                anim.SetBool("Space", true);
            }
        }
        if (Input.GetKey(KeyCode.H) && anim.GetBool("Space"))
        {
            SceneManager.LoadScene("HighscoreScene");
        }
    }
}
