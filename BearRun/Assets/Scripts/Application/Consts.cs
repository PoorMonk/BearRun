using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts{

    public const string E_ExitEvent = "E_ExitEvent";
    public const string E_EnterEvent = "E_EnterEvent";
    public const string E_StartUp = "E_StartUp";

    public const string V_PlayerMove = "V_PlayerMove";
}

public enum InputDirection
{
    NULL,
    RIGHT,
    LEFT,
    UP,
    DOWN
}
