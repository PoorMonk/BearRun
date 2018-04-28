using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EquipFootballController : Controller
{
    public override void Execute(object data)
    {
        BuyFootballArgs e = data as BuyFootballArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();

        gm.TakeOnFootball = e.index;
        shop.UpdateFootballBuyBtn(e.index);
        shop.UpdataFootballGizmo();
    }
}
