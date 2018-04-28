using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using Random = UnityEngine.Random;

public class BuyToolsController : Controller
{
    public override void Execute(object data)
    {
        BuyToolsArgs e = data as BuyToolsArgs;
        GameModel gm = GetModel<GameModel>();
        UIBuyTools tool = GetView<UIBuyTools>();
        switch (e.itemKind)
        {
            case ItemKind.NULL:
                if (gm.GetMoney(e.coin))
                {
                    int iValue = Random.Range(0, 3);
                    switch (iValue)
                    {
                        case 0:
                            gm.Magnet++;
                            break;
                        case 1:
                            gm.Invincible++;
                            break;
                        case 2:
                            gm.Multiply++;
                            break;
                    }
                }
                break;
            case ItemKind.INVINCIBLE:
                if (gm.GetMoney(e.coin))
                {
                    gm.Invincible++;
                }
                break;
            case ItemKind.MULTIPLY:
                if (gm.GetMoney(e.coin))
                {
                    gm.Multiply++;
                }
                break;
            case ItemKind.MAGNET:
                if (gm.GetMoney(e.coin))
                {
                    gm.Magnet++;
                }
                break;
            default:
                break;
        }
        tool.Init();
    }
}
