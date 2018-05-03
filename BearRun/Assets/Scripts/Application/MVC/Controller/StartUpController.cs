using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpController : Controller
{
    public override void Execute(object data)
    {
        RegisterController(Consts.E_EnterEvent, typeof(EnterScenesController));
        RegisterController(Consts.E_ExitEvent, typeof(ExitSceneController));
        RegisterController(Consts.E_EndGame, typeof(EndGameController));
        RegisterController(Consts.E_PauseGame, typeof(PauseGameController));
        RegisterController(Consts.E_ResumeGame, typeof(ResumeGameController));
        RegisterController(Consts.E_HitItem, typeof(HitItemController));
        RegisterController(Consts.E_FinalShowUI, typeof(FinalShowUIController));
        RegisterController(Consts.E_BriberyClick, typeof(BriberyClickController));
        RegisterController(Consts.E_ContinueGame, typeof(ContinueGameController));
        RegisterController(Consts.E_BuyTools, typeof(BuyToolsController));
        RegisterController(Consts.E_BuyFootball, typeof(BuyFootballController));
        RegisterController(Consts.E_EquipFootball, typeof(EquipFootballController));
        RegisterController(Consts.E_BuySkinCloth, typeof(BuySkinClothController));
        RegisterController(Consts.E_EquipSkin, typeof(EquipSkinController));

        RegisterModel(new GameModel());
        GameModel gm = GetModel<GameModel>();
        gm.Init();
    }
}
