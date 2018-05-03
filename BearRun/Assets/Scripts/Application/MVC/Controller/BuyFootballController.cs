using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BuyFootballController : Controller
{
    public override void Execute(object data)
    {
        BuyFootballArgs e = data as BuyFootballArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();
        if (gm.GetMoney(e.coin))
        {
            gm.BuyFootBall.Add(e.index);
            shop.UpdateFootballBuyBtn(e.index);
            shop.UpdataFootballGizmo();
            shop.UpdateUI();
        }
        
    }
}
