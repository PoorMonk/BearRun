using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EquipSkinController : Controller
{
    public override void Execute(object data)
    {
        BuySkinClothArgs e = data as BuySkinClothArgs;
        GameModel gm = GetModel<GameModel>();
        UIShop shop = GetView<UIShop>();

        Debug.Log("skinID:" + e.skinIndex.SkinID + ", " + e.skinIndex.ClothID);
        gm.TakeOnSkin = e.skinIndex;
        shop.UpdateUI();
        //shop.UpdateSkinBuybtn(e.skinIndex.SkinID);
        //shop.UpdateSkinGizmo();
    }
}


