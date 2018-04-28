using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnterScenesController : Controller
{
    public override void Execute(object data)
    {
        SceneArgs e = data as SceneArgs;
        switch (e.sceneIndex)
        {
            case 1:
                RegisterView(GameObject.Find("Canvas").transform.Find("UIMainMenu").GetComponent<UIMainMenu>());
                break;
            case 2:
                RegisterView(GameObject.Find("Canvas").transform.Find("UIShop").GetComponent<UIShop>());
                break;
            case 3:
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBuyTools").GetComponent<UIBuyTools>());
                break;
            case 4:
                RegisterView(GameObject.FindWithTag(Tags.player).GetComponent<PlayerMove>());
                RegisterView(GameObject.FindWithTag(Tags.player).GetComponent<PlayerAnim>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<UIBoard>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIPause").GetComponent<UIPause>()); 
                RegisterView(GameObject.Find("Canvas").transform.Find("UIResume").GetComponent<UIResume>()); 
                RegisterView(GameObject.Find("Canvas").transform.Find("UIDead").GetComponent<UIDead>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIFinalScore").GetComponent<UIFinalScore>());
                

                GameModel gm = GetModel<GameModel>();
                gm.IsPause = false;
                gm.IsPlay = true;
                break;
        }
    }
}