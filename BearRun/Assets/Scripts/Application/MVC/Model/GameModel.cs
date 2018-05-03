using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : Model
{
    #region 常量
    const int InitCoin = 5000;
    #endregion

    #region 事件
    #endregion

    #region 字段
    bool m_isPause = false;
    bool m_isPlay = true;
    int m_skillTime = 5;
    int m_magnet;
    int m_multiply;
    int m_invincible;

    int m_grade;
    int m_exp;

    int m_coin;
    private int takeOnFootball = 0;
    public List<int> BuyFootBall = new List<int>();

    SkinIndex takeOnSkin = new SkinIndex { SkinID = 0, ClothID = 0 };
    public List<SkinIndex> BuySkinCloth = new List<SkinIndex>();

    public int lastIndex = 1;
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

    public int SkillTime
    {
        get
        {
            return m_skillTime;
        }

        set
        {
            m_skillTime = value;
        }
    }

    public int Magnet
    {
        get
        {
            return m_magnet;
        }

        set
        {
            m_magnet = value;
        }
    }

    public int Multiply
    {
        get
        {
            return m_multiply;
        }

        set
        {
            m_multiply = value;
        }
    }

    public int Invincible
    {
        get
        {
            return m_invincible;
        }

        set
        {
            m_invincible = value;
        }
    }

    public int Grade
    {
        get
        {
            return m_grade;
        }

        set
        {
            m_grade = value;
        }
    }

    public int Exp
    {
        get
        {
            return m_exp;
        }

        set
        {
            //判断是否要升级
            while (500 + Grade * 100 < value)
            {                
                value -= 500 + Grade * 100;
                Grade++;
            }
            m_exp = value;
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
        }
    }

    public int TakeOnFootball
    {
        get
        {
            return takeOnFootball;
        }

        set
        {
            takeOnFootball = value;
        }
    }

    public SkinIndex TakeOnSkin
    {
        get
        {
            return takeOnSkin;
        }

        set
        {
            takeOnSkin = value;
        }
    }
    #endregion

    #region 方法
    public void Init()
    {
        m_invincible = 0;
        m_magnet = 0;
        m_multiply = 0;
        m_skillTime = 5;
        m_grade = 1;
        m_exp = 0;
        m_coin = InitCoin;
        InitSkin();
    }

    void InitSkin()
    {
        BuyFootBall.Add(TakeOnFootball);
        BuySkinCloth.Add(TakeOnSkin);
    }

    //买东西
    public bool GetMoney(int coin)
    {
        if (coin <= Coin)
        {
            Coin -= coin;
            return true;
        }
        return false;
    }

    public ItemState GetFootballState(int i)
    {
        if (i == TakeOnFootball)
        {
            return ItemState.EQUIP;
        }
        else if(BuyFootBall.Contains(i))
        {
            return ItemState.BUY;
        }
        else
        {
            return ItemState.UNBUY;
        }
    }

    public ItemState GetSkinState(int i)
    {
        if (takeOnSkin.SkinID == i)
        {
            return ItemState.EQUIP;
        }
        else
        {
            foreach (var item in BuySkinCloth)
            {
                if (item.SkinID == i)
                {
                    return ItemState.BUY;
                }
            }
            return ItemState.UNBUY;
        }
    }

    public ItemState GetClothState(SkinIndex index)
    {
        if (takeOnSkin.SkinID == index.SkinID && TakeOnSkin.ClothID == index.ClothID)
        {
            return ItemState.EQUIP;
        }
        else
        {
            foreach (var item in BuySkinCloth)
            {
                if (item.SkinID == index.SkinID && item.ClothID == index.ClothID)
                {
                    return ItemState.BUY;
                }
            }
            return ItemState.UNBUY;
        }
    }
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法
    #endregion



}

public class SkinIndex
{
    public int SkinID;
    public int ClothID;
}
