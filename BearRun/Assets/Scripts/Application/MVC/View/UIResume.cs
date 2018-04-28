using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResume : View
{
    public Image imgCount;
    public Sprite[] spCount;

    public override string Name
    {
        get
        {
            return Consts.V_UIResume;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    public void StartCount()
    {
        Show();
        StartCoroutine(StartCountCor());
    }

    IEnumerator StartCountCor()
    {
        int i = 3;
        while (0 < i)
        {
            imgCount.sprite = spCount[i - 1];
            i--;
            yield return new WaitForSeconds(1);            
        }
        Hide();
        // TODO
        //GameModel gm = GetModel<GameModel>();
        //gm.IsPause = false;
        //gm.IsPlay = true;
        SendEvent(Consts.E_ContinueGame);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
