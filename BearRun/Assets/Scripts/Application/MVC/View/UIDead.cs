using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDead : View
{
    int m_briberyTime = 1;
    public Text textBriberyTime;

    public override string Name
    {
        get
        {
            return Consts.V_UIDead;
        }
    }

    public int BriberyTime
    {
        get
        {
            return m_briberyTime;
        }

        set
        {
            m_briberyTime = value;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    public void Show()
    {
        textBriberyTime.text = (500 * BriberyTime).ToString();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnCancleClicked()
    {
        SendEvent(Consts.E_FinalShowUI);
    }

    public void OnBriberyClicked()
    {
        CoinArgs e = new CoinArgs
        {
            coin = BriberyTime * 500
        };
        SendEvent(Consts.E_BriberyClick, e);
    }
}
