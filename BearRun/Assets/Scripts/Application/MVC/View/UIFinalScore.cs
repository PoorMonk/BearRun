using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFinalScore : View
{
    public Text textDis;
    public Text textCoin;
    public Text textScore;
    public Text textGoal;

    public Slider sliExpslider;
    public Text textExp;
    public Text textLevel;

    public override string Name
    {
        get
        {
            return Consts.V_UIFinalScore;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateUI(int dis, int coin, int goal, int exp, int grade)
    {
        textDis.text = dis.ToString();
        textCoin.text = coin.ToString();
        textGoal.text = goal.ToString();
        textScore.text = (dis * (goal + 1) + coin).ToString();
        textExp.text = exp.ToString() + "/" + (500 + grade * 100).ToString();
        sliExpslider.value = (float)exp / (500 + grade * 100);
        textLevel.text = grade.ToString() + "级";
    }

    public void OnbtnReplayClicked()
    {
        Game.Instance.LoadLevel(4);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnbtnShopClicked()
    {
        Game.Instance.LoadLevel(2);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnbtnMainClicked()
    {
        Game.Instance.LoadLevel(1);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }
}
