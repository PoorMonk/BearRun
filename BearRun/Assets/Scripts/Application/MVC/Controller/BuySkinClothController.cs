using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BuySkinClothController : Controller
{
    public override void Execute(object data)
    {
        BuySkinClothArgs e = data as BuySkinClothArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();
        if (gm.GetMoney(e.coin))
        {
            gm.BuySkinCloth.Add(e.skinIndex);
            shop.UpdateUI();
            Debug.Log("skin money:" + e.coin);
            //shop.UpdataFootballGizmo();
        }
    }
}
