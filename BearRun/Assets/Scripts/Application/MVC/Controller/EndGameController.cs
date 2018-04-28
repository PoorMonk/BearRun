using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EndGameController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();
        gm.IsPlay = false;

        //todo:显示ENDUI
        UIDead uiDead = GetView<UIDead>();
        uiDead.Show();
    }
}
