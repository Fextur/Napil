using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantScript : MonoBehaviour
{
    Animator anim;
    int tilt = 0;
    float time;
    float nextTik = 0;
    float nextCheck = 0;
    float maxTime = 1f;
    public bool jump = false;
    float jumpTime = 0;
    float crouchTime = 0;

    float Maxie = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        time = Time.time;
        tilt = anim.GetInteger("Tilt");
        LoseCheck();
        if (tilt > 2 || tilt < -2)
        {
            Placer();
            return;
        }
        if (jump == true)
        {
            Jump();
            return;
        }
        else Placer();
        if (maxTime > 0.2f) maxTime -= 0.0001f;
        
        if (anim.GetBool("Puff") && Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Puff", false);
            anim.SetInteger("Tilt", tilt - 1);
        }
        if (nextTik == 0)
        {
            if(anim.GetBool("Puff")) nextTik = time + maxTime/2;
            else nextTik = time + maxTime;
        }
        if (nextCheck == 0) nextCheck = time + 0.1f;
        if (nextTik < time)
        {
            Placer();
            nextTik = time + 2f;
            if (anim.GetBool("Puff")) anim.SetInteger("Tilt", tilt - 1);
            else if (tilt < 0) anim.SetInteger("Tilt", tilt - 1);
            else if (tilt > 0) anim.SetInteger("Tilt", tilt + 1);
            else anim.SetInteger("Tilt", (Random.Range(-1, 2)));
            tilt = anim.GetInteger("Tilt");
        }
        if (Input.GetKey(KeyCode.A) && nextCheck < time)
        {
            anim.SetInteger("Tilt", tilt - 1);
            nextCheck = time + 0.1f;
        }
        if (Input.GetKey(KeyCode.D) && nextCheck < time)
        {
            anim.SetInteger("Tilt", tilt + 1);
            nextCheck = time + 0.1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            jump = true;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Puff", true);
        }
    }

    void Jump()
    {
        Vector3 pos = transform.position;
        if (jumpTime == 0) jumpTime = time + 1f;
        if (time > jumpTime)
        {
            jumpTime = 0;
            jump = false;
            pos.y = 0.16f;
            transform.position = pos;
            if(tilt > 1)
                anim.SetInteger("Tilt", 3);
            if(tilt < -1)
                anim.SetInteger("Tilt", -3);
            return;
        }
        if (tilt > 1)
        {
            pos.y -= (jumpTime - time) * Time.deltaTime;
            pos.x += (jumpTime - time) * 2 * Time.deltaTime;
        }

        else if (tilt < -1)
        {
            pos.y -= (jumpTime - time) * 0.6f * Time.deltaTime;
            pos.x -= (jumpTime - time) * 0.1f * Time.deltaTime;
        }

        else anim.SetInteger("Tilt", 0);
        if (time + 0.5f < jumpTime)
        {
            pos.y += 0.05f * Time.deltaTime * 50;
        }
        else pos.y -= 0.05f * Time.deltaTime * 50;
        
        transform.position = pos;
    }

    void Placer()
    {
        Vector3 pos = transform.position;
        if (tilt == 0)
        {
            pos.x = -4.59f;
            pos.y = 0.39f;
        }
        if (tilt == 1)
        {
            pos.x = -3.77f;
            pos.y = 0.24f;
        }
        if (tilt == 2)
        {
            pos.x = -3.21f;
            pos.y = 0.06f;
        }
        if (tilt == 3)
        {
            pos.x = -2.21f;
            pos.y = -0.52f;
        }
        if (tilt == -1)
        {
            pos.x = -4.96f;
            pos.y = 0.44f;
        }
        if (tilt == -2)
        {
            pos.x = -6.74f;
            pos.y = 0.96f;
        }
        if (tilt == -3)
        {
            pos.x = -7.64f;
            pos.y = -0.37f;
        }
        transform.position = pos;
    }

    void LoseCheck()
    {
        if(tilt > 2)
        {
            GameObject.Find("Master").GetComponent<GameMaster>().Lose = true;
            GameObject.Find("Master").GetComponent<GameMaster>().LoseCause = "Right";
        }
        if (tilt < -2)
        {
            GameObject.Find("Master").GetComponent<GameMaster>().Lose = true;
            GameObject.Find("Master").GetComponent<GameMaster>().LoseCause = "Left";
        }
    }
}

