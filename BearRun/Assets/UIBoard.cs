using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoard : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    int m_coin = 0;
    int m_distance = 0;

    public Text textCoin;
    public Text textDistance;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Consts.V_UIBoard;
        }
    }

    public int Coin
    {
        get
        {
            return m_coin;
        }

        set
        {
            m_coin = value;
            textCoin.text = value.ToString();
        }
    }

    public int Distance
    {
        get
        {
            return m_distance;
        }

        set
        {
            m_distance = value;
            textDistance.text = value.ToString() + "米";
        }
    }
    #endregion

    #region 方法
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_UpdateDis:
                DistanceArgs da = data as DistanceArgs;
                Distance = da.distance;
                break;
            case Consts.E_UpdateCoin:
                CoinArgs ca = data as CoinArgs;
                Coin += ca.coin;
                break;
        }
    }

    public override void RegisterAttentionEvent()
    {
        AttentionList.Add(Consts.E_UpdateDis);
        AttentionList.Add(Consts.E_UpdateCoin);
    }
    #endregion

    #region 帮助方法
    #endregion





}
