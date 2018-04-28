using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : View
{
    public Text textDis;
    public Text textScore;
    public Text textCoin;

    public override string Name
    {
        get
        {
            return Consts.V_UIPause;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    public void OnResumeClicked()
    {
        Hide();
        SendEvent(Consts.E_ResumeGame);
    }
}
