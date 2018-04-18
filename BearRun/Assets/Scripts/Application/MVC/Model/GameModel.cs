using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : Model
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    bool m_isPause = false;
    bool m_isPlay = true;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Consts.M_GameModel;
        }
    }

    public bool IsPlay
    {
        get
        {
            return m_isPlay;
        }

        set
        {
            m_isPlay = value;
        }
    }

    public bool IsPause
    {
        get
        {
            return m_isPause;
        }

        set
        {
            m_isPause = value;
        }
    }
    #endregion

    #region 方法
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法
    #endregion



}
