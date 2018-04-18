using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnim : MonoBehaviour {

    Animation m_anim;
    Action PlayAnim;

    private void Awake()
    {
        m_anim = GetComponent<Animation>();
        PlayAnim = PlayRun;
    }

    private void Update()
    {
        if (PlayAnim != null)
        {
            PlayAnim();
        }
    }

    void PlayRun()
    {
        m_anim.Play("run");
    }

    void PlayLeft()
    {
        m_anim.Play("left_jump");
        if (m_anim["left_jump"].normalizedTime > 0.95f)
        {
            PlayAnim = PlayRun;
        }
    }

    void PlayRight()
    {
        m_anim.Play("right_jump");
        if (m_anim["right_jump"].normalizedTime > 0.95f)
        {
            PlayAnim = PlayRun;
        }
    }

    void PlayRoll()
    {
        m_anim.Play("roll");
        if (m_anim["roll"].normalizedTime > 0.95f)
        {
            PlayAnim = PlayRun;
        }
    }

    void PlayJump()
    {
        m_anim.Play("jump");
        if (m_anim["jump"].normalizedTime > 0.95f)
        {
            PlayAnim = PlayRun;
        }
    }

    public void PlayAnimation(InputDirection dir)
    {
        switch (dir)
        {
            case InputDirection.NULL:
                break;
            case InputDirection.RIGHT:
                PlayAnim = PlayRight;
                break;
            case InputDirection.LEFT:
                PlayAnim = PlayLeft;
                break;
            case InputDirection.UP:
                PlayAnim = PlayJump;
                break;
            case InputDirection.DOWN:
                PlayAnim = PlayRoll;
                break;
            default:
                break;
        }
    }
}
