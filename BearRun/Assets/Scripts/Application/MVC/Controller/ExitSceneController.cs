using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ExitSceneController : Controller
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
                Game.Instance.m_objectPool.Clear();

                break;
        }
        GameModel gm = GetModel<GameModel>();
        gm.lastIndex = e.sceneIndex;
    }
}
