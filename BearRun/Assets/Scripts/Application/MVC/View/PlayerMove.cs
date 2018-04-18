using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    private CharacterController m_cc;
    public float m_speed = 20f;
    InputDirection m_inputDir = InputDirection.NULL;
    bool activeInput = false;
    Vector3 m_mousePos;

    int m_nowIndex = 1;
    int m_targetIndex = 1;
    float m_xDistance;
    float m_yDistance;
    float m_jumpValue = 5;
    float m_grivaty = 9.8f;
    float m_moveSpeed = 13f;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Consts.V_PlayerMove;
        }
    }
    #endregion

    #region 方法
    IEnumerator UpdateAction()
    {
        while (true)
        {
            m_yDistance -= m_grivaty * Time.deltaTime;
            m_cc.Move((transform.forward * m_speed + new Vector3(0, m_yDistance, 0)) * Time.deltaTime);
            UpdatePosition();
            MoveControl();
            yield return 0;
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
                }
                break;
            case InputDirection.LEFT:
                if (m_targetIndex > 0)
                {
                    m_targetIndex--;
                    m_xDistance = -2;
                    SendMessage("PlayAnimation", m_inputDir);
                }
                break;
            case InputDirection.UP:
                if (m_cc.isGrounded)
                {
                    m_yDistance = m_jumpValue;
                }
                SendMessage("PlayAnimation", m_inputDir);
                break;
            case InputDirection.DOWN:
                SendMessage("PlayAnimation", m_inputDir);
                break;
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

    #region Unity回调
    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
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
