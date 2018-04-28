using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FinalShowUIController : Controller
{

    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();
        UIBoard board = GetView<UIBoard>();
        board.Hide();
        UIFinalScore final = GetView<UIFinalScore>();
        final.Show();
        gm.Exp += board.Coin + board.Distance * (board.GoalCount + 1);
        final.UpdateUI(board.Distance, board.Coin, board.GoalCount, gm.Exp, gm.Grade);
        UIDead dead = GetView<UIDead>();
        dead.Hide();
        
    }
}
