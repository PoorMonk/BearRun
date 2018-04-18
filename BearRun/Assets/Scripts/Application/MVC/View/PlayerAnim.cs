using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnim : View {

    Animation m_anim;
    Action PlayAnim;
    GameModel m_gameModel;

    public override string Name
    {
        get
        {
            return Consts.V_PlayerAnim;
        }
    }

    private void Awake()
    {
        m_anim = GetComponent<Animation>();
        m_gameModel = GetModel<GameModel>();
        PlayAnim = PlayRun;
    }

    private void Update()
    {
        if (PlayAnim != null)
        {
            if (m_gameModel.IsPlay && !m_gameModel.IsPause)
            {
                PlayAnim();
            }
            else
            {
                m_anim.Stop();
            }
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

    public override void HandleEvent(string eventName, object data)
    {
        throw new NotImplementedException();
    }
}
