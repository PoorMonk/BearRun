using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HitItemController : Controller
{
    public override void Execute(object data)
    {
        ItemArgs e = data as ItemArgs;
        PlayerMove player = GetView<PlayerMove>();
        GameModel gm = GetModel<GameModel>();
        UIBoard ui = GetView<UIBoard>();
        switch (e.kind)
        {
            case ItemKind.INVINCIBLE:
                player.HitInvincible();
                gm.Invincible -= e.hitCount;
                ui.HitInvincible();
                break;
            case ItemKind.MULTIPLY:
                player.EatMultiply();
                gm.Multiply -= e.hitCount;
                ui.EatMultiply();
                break;
            case ItemKind.MAGNET:
                player.EatMagnet();
                gm.Magnet -= e.hitCount;
                ui.EatMagnet();
                break;
        }
        ui.UpdateUI();
    }
}