using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoard : View
{
    #region 常量
    public const int startTime = 50;
    #endregion

    #region 事件
    #endregion

    #region 字段
    int m_coin = 0;
    int m_distance = 0;
    int m_goalCount = 0;
    float m_times;
    int m_skillTime;

    public Text textCoin;
    public Text textDistance;
    public Text textTimer;
    public Text textGizmoMangent;
    public Text textGizmoMultiply;
    public Text textGizmoInvicible;

    IEnumerator doubleCoinCoroutine;
    IEnumerator magnetCoroutine;
    IEnumerator invincibleCoroutine;

    public Slider sliTimer;
    public Slider sliGoal;

    GameModel gm;

    public Button btnMagnet;
    public Button btnMultiply;
    public Button btnInvincible;
    public Button btnGoal;
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

    public float Times
    {
        get
        {
            return m_times;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
                SendEvent(Consts.E_EndGame);
            }
            else if (startTime < value)
            {
                value = startTime;
            }
            
            m_times = value;
            textTimer.text = m_times.ToString("f2") + "s";
            sliTimer.value = value / startTime;
        }
    }

    public int GoalCount
    {
        get
        {
            return m_goalCount;
        }

        set
        {
            m_goalCount = value;
        }
    }
    #endregion

    #region 方法
    public void OnPauseClicked()
    {
        PauseArgs e = new PauseArgs
        {
            coin = Coin,
            distance = Distance,
            score = Coin + Distance * (GoalCount + 1)
        };
        SendEvent(Consts.E_PauseGame, e);
    }

    public void UpdateUI()
    {
        IsShow(gm.Invincible, btnInvincible);
        IsShow(gm.Magnet, btnMagnet);
        IsShow(gm.Multiply, btnMultiply);
    }

    public void IsShow(int i, Button btn)
    {
        if (i > 0)
        {
            btn.interactable = true;
            btn.transform.Find("Mask").gameObject.SetActive(false);
        }
        else
        {
            btn.interactable = false;
            btn.transform.Find("Mask").gameObject.SetActive(true);
        }
    }

    public void EatMagnet()
    {
        if (magnetCoroutine != null)
        {
            StopCoroutine(magnetCoroutine);
        }
        magnetCoroutine = MagnetCoroutine();
        StartCoroutine(magnetCoroutine);
    }

    IEnumerator MagnetCoroutine()
    {       
        float timer = gm.SkillTime;
        textGizmoMangent.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (gm.IsPlay && !gm.IsPause)
            {
                timer -= Time.deltaTime;
                textGizmoMangent.text = GetTime(timer);
            }                           
            yield return 0;
        }
        textGizmoMangent.transform.parent.gameObject.SetActive(false);
    }

    //双倍金币
    public void EatMultiply()
    {
        if (doubleCoinCoroutine != null)
        {
            StopCoroutine(doubleCoinCoroutine);
        }
        doubleCoinCoroutine = MultiplyCoroutine();
        StartCoroutine(doubleCoinCoroutine);
    }

    IEnumerator MultiplyCoroutine()
    {
        float timer = gm.SkillTime;
        textGizmoMultiply.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (gm.IsPlay && !gm.IsPause)
            {
                timer -= Time.deltaTime;
                textGizmoMultiply.text = GetTime(timer);
            }
            yield return 0;
        }
        textGizmoMultiply.transform.parent.gameObject.SetActive(false);
    }

    public void HitInvincible()
    {
        if (invincibleCoroutine != null)
            StopCoroutine(invincibleCoroutine);
        invincibleCoroutine = InvincibleCoroutine();
        StartCoroutine(invincibleCoroutine);
    }

    IEnumerator InvincibleCoroutine()
    {
        float timer = gm.SkillTime;
        textGizmoInvicible.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (gm.IsPlay && !gm.IsPause)
            {
                timer -= Time.deltaTime;
                textGizmoInvicible.text = GetTime(timer);
            }
            yield return 0;
        }
        textGizmoInvicible.transform.parent.gameObject.SetActive(false);
    }

    string GetTime(float time)
    {
        return ((int)time + 1).ToString();
    }

    public void OnMagnetClicked()
    {
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            kind = ItemKind.MAGNET
        };
        SendEvent(Consts.E_HitItem, e);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnInvicinbleClicked()
    {
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            kind = ItemKind.INVINCIBLE
        };
        SendEvent(Consts.E_HitItem, e);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnMultiplyClicked()
    {
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            kind = ItemKind.MULTIPLY
        };
        SendEvent(Consts.E_HitItem, e);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    private void ShowGoalClick()
    {
        //slide可以显示
        StartCoroutine(StartCountDown());
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
        //btn可以按下
    }

    IEnumerator StartCountDown()
    {
        btnGoal.interactable = true;
        sliGoal.value = 1;
        //Debug.Log(sliGoal);
        while (sliGoal.value > 0)
        {
            if (gm.IsPlay && !gm.IsPause)
                sliGoal.value -= 1.5f * Time.deltaTime;
            yield return 0;
        }
        btnGoal.interactable = false;
        sliGoal.value = 0;
    }

    public void OnGoalBtnClicked()
    {
        SendEvent(Consts.E_ClickGoalButton);
        sliGoal.value = 0;
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
        //Debug.Log("OnGoalBtnClicked---");
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    

    #endregion

    #region Unity回调
    private void Awake()
    {
        Times = startTime;
        gm = GetModel<GameModel>();
        UpdateUI();
        m_skillTime = gm.SkillTime;
    }

    private void Update()
    {
        if (gm.IsPlay && !gm.IsPause)
            Times -= Time.deltaTime;
    }
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
            case Consts.E_HitAddTime:
                Times += 20;
                break;
            case Consts.E_HitGoalTrigger:
                ShowGoalClick();
                break;
            case Consts.E_ShootGoal:
                GoalCount += 1;
                break;
        }
    }

    public override void RegisterAttentionEvent()
    {
        AttentionList.Add(Consts.E_UpdateDis);
        AttentionList.Add(Consts.E_UpdateCoin);
        AttentionList.Add(Consts.E_HitAddTime);
        AttentionList.Add(Consts.E_HitGoalTrigger);
        AttentionList.Add(Consts.E_ClickGoalButton);
        AttentionList.Add(Consts.E_ShootGoal);
    }


    #endregion

    #region 帮助方法
    #endregion





}
