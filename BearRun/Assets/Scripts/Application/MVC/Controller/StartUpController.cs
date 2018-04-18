using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpController : Controller
{
    public override void Execute(object data)
    {
        RegisterController(Consts.E_EnterEvent, typeof(EnterScenesController));
        RegisterController(Consts.E_EndGame, typeof(EndGameController));

        RegisterModel(new GameModel());
    }
}
