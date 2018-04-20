using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts{

    public const string E_ExitEvent = "E_ExitEvent";
    public const string E_EnterEvent = "E_EnterEvent";
    public const string E_StartUp = "E_StartUp";
    public const string E_EndGame = "E_EndGame";

    public const string E_UpdateDis = "E_UpdateDis";
    public const string E_UpdateCoin = "E_UpdateCoin";

    public const string V_PlayerMove = "V_PlayerMove";
    public const string V_PlayerAnim = "V_PlayerAnim";
    public const string V_UIBoard = "V_UIBoard";

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
