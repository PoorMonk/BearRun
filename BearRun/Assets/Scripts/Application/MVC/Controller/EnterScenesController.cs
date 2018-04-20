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
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                RegisterView(GameObject.FindWithTag(Tags.player).GetComponent<PlayerMove>());
                RegisterView(GameObject.FindWithTag(Tags.player).GetComponent<PlayerAnim>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<UIBoard>());
                break;
        }
    }
}