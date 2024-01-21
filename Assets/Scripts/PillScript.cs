using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillScript : MonoBehaviour
{
    Animator anim;
    int tilt = 0;
    public int jump = 0;
    public bool puff = false;
    float time;

    float nextTik = 0;

    float MaxOffset = 3f;
    float MinOffset = 2f;
    float AbsMaxOffset = 0.75f;
    float AbsMinOffset = 0.5f;

    float InputTimer = 0;

    float JumpTik = 0;
    float PuffTik = 0;

    bool SpaceyFucker = false;

    bool AudioPlayed = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        time = Time.time;
        tilt = anim.GetInteger("Tilt");
        jump = anim.GetInteger("Jump");
        puff = anim.GetBool("Puff");
        LoseCheck();
        CheckFallies();
        TikkerDowner();
        Placer();
        if (jump != 0 && jump != 10)
        {
            Jump();
            return;
        }
        if (GameObject.Find("Master").GetComponent<GameMaster>().Lose == true)
        {
            if (!AudioPlayed)
            {
                GetComponent<AudioSource>().Play();
                AudioPlayed = true;
            }
            return;
        }
        if (puff) Puff();
        Unbalance();
        if (InputTimer < time && Input.anyKey) CheckInput();
    }
    void CheckFallies()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FallLeft"))
        {
            anim.SetInteger("Tilt", -3);
            tilt = anim.GetInteger("Tilt");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FallRight"))
        {
            anim.SetInteger("Tilt", 3);
            tilt = anim.GetInteger("Tilt");
        }
        if (tilt == -3 || tilt == 3)
        {
            anim.SetBool("Puff", false);
            puff = anim.GetBool("Puff");
        }

    }

    void Placer()
    {
        Vector3 pos = transform.position;
        if (anim.GetInteger("Jump") != 0)
        {
            switch (jump)
            {
                case 1:
                case 5:
                    if (tilt > 0)
                    {
                        pos.x = -3.05f;
                        pos.y = 0.38f;
                    }
                    else if (tilt < 0)
                    {
                        pos.x = -5.72f;
                        pos.y = 0.55f;

                    }
                    else
                    {
                        pos.x = -4.55f;
                        pos.y = 1.09f;
                    }
                    break;
                case 2:
                case 4:
                    if (tilt > 0)
                    {
                        pos.x = -1.13f;
                        pos.y = 0.81f;
                    }
                    else if (tilt < 0)
                    {
                        pos.x = -6.7f;
                        pos.y = -0.36f;
                    }
                    else
                    {
                        pos.x = -4.37f;
                        pos.y = 2.06f;
                    }
                    break;
                case 3:
                    if (tilt > 0)
                    {
                        pos.x = 0.66f;
                        pos.y = -0.15f;
                    }
                    else if (tilt < 0)
                    {
                        pos.x = -7.49f;
                        pos.y = -0.38f;
                    }
                    else
                    {
                        pos.x = -3.96f;
                        pos.y = 3.08f;
                    }
                    break;
                case 10:
                    if (tilt > 0)
                    {
                        pos.x = 1.96f;
                        pos.y = -1.09f;
                    }
                    else if (tilt < 0)
                    {
                        pos.x = -9.09f;
                        pos.y = -0.69f;
                    }
                    break;
            }
            transform.position = pos;
            return;
        }
        switch (tilt)
        {
            case 0:
                if (anim.GetBool("Puff"))
                {
                    pos.x = -3.86f;
                    pos.y = 0.23f;
                }
                else
                {
                    pos.x = -4.59f;
                    pos.y = 0.39f;
                }
                break;
            case 1:
                if (anim.GetBool("Puff"))
                {
                    pos.x = -3.41f;
                    pos.y = -0.13f;
                }
                else
                {
                    pos.x = -3.77f;
                    pos.y = 0.24f;
                }
                break;
            case 2:
                if (anim.GetBool("Puff"))
                {
                    pos.x = -2.9f;
                    pos.y = -0.04f;
                }
                else
                {
                    pos.x = -3.21f;
                    pos.y = 0.06f;
                }
                break;
            case 3:
                pos.x = -2.21f;
                pos.y = -0.52f;
                break;
            case -1:
                if (anim.GetBool("Puff"))
                {
                    pos.x = -4.99f;
                    pos.y = 0.31f;
                }
                else
                {
                    pos.x = -4.96f;
                    pos.y = 0.44f;
                }
                break;
            case -2:
                if (anim.GetBool("Puff"))
                {
                    pos.x = -6.63f;
                    pos.y = 0.85f;
                }
                else
                {
                    pos.x = -6.74f;
                    pos.y = 0.96f;
                }
                break;
            case -3:
                pos.x = -7.64f;
                pos.y = -0.37f;
                break;
        }
        transform.position = pos;
    }

    void LoseCheck()
    {
        if (tilt > 2)
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

    void Jump()
    {
        if (JumpTik == 0)
        {
            GameObject.Find("Jump").GetComponent<AudioSource>().Play();
            JumpTik = time + 0.05f;
            if (tilt > 1) anim.SetInteger("Tilt", 3);
            else if (tilt < -1) anim.SetInteger("Tilt", -3);
            else anim.SetInteger("Tilt", 0);
            tilt = anim.GetInteger("Tilt");
        }
        if (JumpTik < time)
        {
            if (jump < 2) JumpTik = time + 0.05f;
            else if (jump == 2) JumpTik = time + 0.075f;
            else if (jump == 3 && tilt != 0)
            {
                anim.SetInteger("Jump", 10);
                return;
            }
            else JumpTik = time + 0.04f;
            if (jump > 5)
            {
                JumpTik = 0;
                anim.SetInteger("Jump", 0);
            }
            else anim.SetInteger("Jump", jump + 1);

        }
    }

    void Unbalance()
    {
        if (nextTik == 0)
        {
            nextTik = time + MaxMin();
        }
        else if (nextTik < time)
        {
            if (puff) nextTik = time + 0.5f;
            else nextTik = time + MaxMin();
            if (tilt < 0 || puff) anim.SetInteger("Tilt", tilt - 1);
            else if (tilt > 0) anim.SetInteger("Tilt", tilt + 1);
            else anim.SetInteger("Tilt", (Random.Range(-1, 2)));
            tilt = anim.GetInteger("Tilt");
        }
    }

    void TikkerDowner()
    {
        if (MaxOffset > AbsMaxOffset) MaxOffset -= 0.0002f;
        if (MinOffset > AbsMinOffset) MinOffset -= 0.0002f;
    }

    float MaxMin()
    {
        return Random.Range(MinOffset, MaxOffset + 0.000001f);
    }

    void CheckInput()
    {
        InputTimer = time + 0.05f;
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("Tilt", tilt - 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("Tilt", tilt + 1);
        }
        if (Input.GetKeyDown(KeyCode.W) && !puff)
        {
            anim.SetInteger("Jump", 1);
        }
        else if (Input.GetKey(KeyCode.Space) && jump == 0 && !puff)
        {
            anim.SetBool("Puff", true);
            nextTik = time + 0.5f;
        }
        tilt = anim.GetInteger("Tilt");

    }

    void Puff()
    {
        if (PuffTik == 0)
        {
            GameObject.Find("Puffer").GetComponent<AudioSource>().Play();
            PuffTik = time + 0.05f;
        }
        if (PuffTik > time) return;
        if (!Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Puff", false);
            anim.SetInteger("Tilt", tilt - 1);
            tilt = anim.GetInteger("Tilt");
            PuffTik = 0;
            GameObject.Find("Puffer").GetComponent<AudioSource>().Stop();
        }
    }
}
