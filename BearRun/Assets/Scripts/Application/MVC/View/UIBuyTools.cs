using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyTools : View
{
    GameModel gm;
    public Text m_textMagnet;
    public Text m_textMultiply;
    public Text m_textInvincible;
    public Text m_textCoin;

    public override string Name
    {
        get
        {
            return Consts.V_UIBuyTools;
        }
    }

    private void Awake()
    {
        gm = GetModel<GameModel>();
        Init();
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    public void Init()
    {
        m_textCoin.text = gm.Coin.ToString();
        ShowOrHide(gm.Magnet, m_textMagnet);
        ShowOrHide(gm.Multiply, m_textMultiply);
        ShowOrHide(gm.Invincible, m_textInvincible);
    }

    private void ShowOrHide(int iCount, Text txt)
    {
        if (0 < iCount)
        {
            txt.transform.parent.gameObject.SetActive(true);
            txt.text = iCount.ToString();
        }
        else
        {
            txt.transform.parent.gameObject.SetActive(false);
        }
    }

    public void OnbtnMagnetClicked()
    {
        BuyToolsArgs e = new BuyToolsArgs{
            itemKind = ItemKind.MAGNET,
            coin = 100
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    public void OnbtnMultiplyClicked()
    {
        BuyToolsArgs e = new BuyToolsArgs
        {
            itemKind = ItemKind.MULTIPLY,
            coin = 200
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    public void OnbtnInvincibleClicked()
    {
        BuyToolsArgs e = new BuyToolsArgs
        {
            itemKind = ItemKind.INVINCIBLE,
            coin = 200
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    public void OnbtnRandomToolClicked()
    {
        BuyToolsArgs e = new BuyToolsArgs
        {
            itemKind = ItemKind.NULL,
            coin = 300
        };
        SendEvent(Consts.E_BuyTools, e);
    }

    public void OnbtnStartGameClicked()
    {
        Game.Instance.LoadLevel(4);
    }
}
