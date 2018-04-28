using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BriberyClickController : Controller
{
    public override void Execute(object data)
    {
        CoinArgs e = data as CoinArgs;
        UIDead dead = GetView<UIDead>();
        GameModel gm = GetModel<GameModel>();
        if (gm.GetMoney(e.coin))
        {
            dead.Hide();
            UIResume resume = GetView<UIResume>();
            resume.StartCount();
            dead.BriberyTime++;
        }

        
    }
}
