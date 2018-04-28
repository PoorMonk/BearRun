using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts{

    public const string E_ExitEvent = "E_ExitEvent";
    public const string E_EnterEvent = "E_EnterEvent";
    public const string E_StartUp = "E_StartUp";
    public const string E_EndGame = "E_EndGame";

    public const string E_PauseGame = "E_PauseGame";
    public const string E_ResumeGame = "E_ResumeGame";

    public const string E_UpdateDis = "E_UpdateDis";
    public const string E_UpdateCoin = "E_UpdateCoin";
    public const string E_HitAddTime = "E_HitAddTime";

    public const string E_HitItem = "E_HitItem";
    public const string E_HitGoalTrigger = "E_HitGoalTrigger";
    public const string E_ClickGoalButton = "E_ClickGoalButton";
    public const string E_ShootGoal = "E_ShootGoal";
    public const string E_FinalShowUI = "E_FinalShowUI";
    public const string E_BriberyClick = "E_BriberyClick";
    public const string E_ContinueGame = "E_ContinueGame";
    public const string E_BuyTools = "E_BuyTools";
    public const string E_BuyFootball = "E_BuyFootball";
    public const string E_EquipFootball = "E_EquipFootball";

    public const string V_PlayerMove = "V_PlayerMove";
    public const string V_PlayerAnim = "V_PlayerAnim";
    public const string V_UIBoard = "V_UIBoard";
    public const string V_UIPause = "V_UIPause";
    public const string V_UIResume = "V_UIResume"; 
    public const string V_UIDead = "V_UIDead";
    public const string V_UIFinalScore = "V_UIFinalScore";
    public const string V_UIBuyTools = "V_UIBuyTools";
    public const string V_UIMainMenu = "V_UIMainMenu";
    public const string V_UIShop = "V_UIShop";

    public const string M_GameModel = "M_GameModel";
}

public enum InputDirection
{
    NULL,
    RIGHT,
    LEFT,
    UP,
    DOWN
}

public enum ItemKind
{
    NULL,
    INVINCIBLE,
    MULTIPLY,
    MAGNET
}

public enum ItemState
{
    BUY,
    UNBUY,
    EQUIP
}
