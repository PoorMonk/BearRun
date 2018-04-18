using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : View
{
    #region 常量
    const float m_jumpValue = 5;
    const float m_grivaty = 9.8f;
    const float m_moveSpeed = 13f; //左右移动

    const float m_slideTime = 0.733f;
    const float m_maxSpeed = 40f;
    const float m_accDistance = 200f;
    const float m_accDelta = 0.5f;
    #endregion

    #region 事件
    #endregion

    #region 字段
    private CharacterController m_cc;
    private float speed = 20f;
    InputDirection m_inputDir = InputDirection.NULL;
    bool activeInput = false;
    Vector3 m_mousePos;

    int m_nowIndex = 1;
    int m_targetIndex = 1;
    float m_xDistance;
    float m_yDistance;

    float m_timeCount = 0.0f; //滑动动画播放时间计时器
    float m_accDistanceCount = 0.0f;  //加速距离统计

    bool m_isSlide = false;

    GameModel m_gameModel;

    float m_maskSpeed;
    float m_accSpeed = 10;  //速度增加的速率
    bool m_isHit = false;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Consts.V_PlayerMove;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
    #endregion

    #region 方法

    #region 移动

    IEnumerator UpdateAction()
    {
        while (true)
        {
            if (m_gameModel.IsPlay && !m_gameModel.IsPause)
            {
                m_yDistance -= m_grivaty * Time.deltaTime;
                m_cc.Move((transform.forward * Speed + new Vector3(0, m_yDistance, 0)) * Time.deltaTime);
                UpdatePosition();
                MoveControl();
                SpeedControl();
                SetSlideState();
            }
           
            yield return 0;
        }
    }

    void SetSlideState()
    {
        if (m_isSlide)
        {
            m_timeCount += Time.deltaTime;
            if (m_slideTime <= m_timeCount)
            {
                m_timeCount = 0.0f;
                m_isSlide = false;
            }
        }
    }

    void GetInputDirection()
    {
        m_inputDir = InputDirection.NULL;

        if (Input.GetMouseButtonDown(0))
        {
            activeInput = true;
            m_mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && activeInput)
        {
            Vector3 dis = Input.mousePosition - m_mousePos;
            if (dis.magnitude > 20)
            {
                if (Mathf.Abs(dis.x) > Mathf.Abs(dis.y) && dis.x > 0)
                {
                    m_inputDir = InputDirection.RIGHT;
                }
                else if (Mathf.Abs(dis.x) > Mathf.Abs(dis.y) && dis.x < 0)
                {
                    m_inputDir = InputDirection.LEFT;
                }
                else if (Mathf.Abs(dis.x) < Mathf.Abs(dis.y) && dis.y < 0)
                {
                    m_inputDir = InputDirection.DOWN;
                }
                else if (Mathf.Abs(dis.x) < Mathf.Abs(dis.y) && dis.y > 0)
                {
                    m_inputDir = InputDirection.UP;
                }
                activeInput = false;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            m_inputDir = InputDirection.UP;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_inputDir = InputDirection.DOWN;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            m_inputDir = InputDirection.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_inputDir = InputDirection.RIGHT;
        }

        print(m_inputDir);
    }

    void UpdatePosition()
    {
        GetInputDirection();
        switch (m_inputDir)
        {
            case InputDirection.RIGHT:
                if (m_targetIndex < 2)
                {
                    m_targetIndex++;
                    m_xDistance = 2;
                    SendMessage("PlayAnimation", m_inputDir);
                    Game.Instance.m_sound.PlayEffect("Se_UI_Huadong");
                }
                break;
            case InputDirection.LEFT:
                if (m_targetIndex > 0)
                {
                    m_targetIndex--;
                    m_xDistance = -2;
                    SendMessage("PlayAnimation", m_inputDir);
                    Game.Instance.m_sound.PlayEffect("Se_UI_Huadong");
                }
                break;
            case InputDirection.UP:
                if (m_cc.isGrounded)
                {
                    m_yDistance = m_jumpValue;
                }
                SendMessage("PlayAnimation", m_inputDir);
                Game.Instance.m_sound.PlayEffect("Se_UI_Jump");
                break;
            case InputDirection.DOWN:
                if (m_isSlide == false)
                {
                    m_isSlide = true;
                    SendMessage("PlayAnimation", m_inputDir);
                    Game.Instance.m_sound.PlayEffect("Se_UI_Slide");
                }                
                break;
        }
    }

    void SpeedControl()
    {
        m_accDistanceCount += Speed * Time.deltaTime;
        if (m_accDistance <= m_accDistanceCount)
        {
            m_accDistanceCount = 0;
            Speed += m_accDelta;
            Speed = Speed > m_maxSpeed ? m_maxSpeed : Speed;
            Debug.Log(m_accDistance);
        }
    }

    void MoveControl()
    {
        if (m_targetIndex != m_nowIndex)
        {
            float move = Mathf.Lerp(0, m_xDistance, m_moveSpeed * Time.deltaTime);
            transform.position += new Vector3(move, 0, 0);
            m_xDistance -= move;
            if (Mathf.Abs(m_xDistance) < 0.05f)
            {
                m_xDistance = 0;
                m_nowIndex = m_targetIndex;
                switch(m_nowIndex)
                {
                    case 0:
                        transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                        break;
                    case 1:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;
                    case 2:
                        transform.position = new Vector3(2, transform.position.y, transform.position.z);
                        break;
                }
            }
        }        
    }
    #endregion

    public void HitObstacles()
    {
        if (m_isHit)
            return;
        m_maskSpeed = Speed;
        Speed = 0;
        m_isHit = true;
        StartCoroutine(DescreaseSpeed());
    }

    IEnumerator DescreaseSpeed()
    {
        while (Speed < m_maskSpeed)
        {
            Speed += m_accSpeed * Time.deltaTime;
            yield return 0;
        }
        m_isHit = true;
    }

    #endregion

    #region Unity回调
    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
        m_gameModel = GetModel<GameModel>();
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.smallFence)
        {
            other.gameObject.SendMessage("HitPlayer", transform.position);
            HitObstacles();
            Game.Instance.m_sound.PlayEffect("Se_UI_Hit");
        }
        else if (other.gameObject.tag == Tags.bigFence)
        {
            if (m_isSlide)
                return;
            other.gameObject.SendMessage("HitPlayer", transform.position);
            HitObstacles();
            Game.Instance.m_sound.PlayEffect("Se_UI_Hit");
        }
        else if (other.gameObject.tag == Tags.block)
        {
            Game.Instance.m_sound.PlayEffect("Se_UI_End");
            other.gameObject.SendMessage("HitPlayer", transform.position);

            //游戏结束
            SendEvent(Consts.E_EndGame);
        }
        else if (other.gameObject.tag == Tags.smallBlock)
        {
            Game.Instance.m_sound.PlayEffect("Se_UI_End");
            other.transform.parent.parent.SendMessage("HitPlayer", transform.position);

            //游戏结束
            SendEvent(Consts.E_EndGame);
        }
    }

    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {

    }
    #endregion

    #region 帮助方法
    #endregion









}
