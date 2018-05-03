using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : View
{
    public SkinnedMeshRenderer skm;
    public MeshRenderer mrBall;
    GameModel gm;

    public override string Name
    {
        get
        {
            return Consts.V_UIMainMenu;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    public void OnbtnStartGameClicked()
    {
        Game.Instance.LoadLevel(3);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnbtnShopClicked()
    {
        Game.Instance.LoadLevel(2);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    private void Awake()
    {
        gm = GetModel<GameModel>();
        skm.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, gm.TakeOnSkin.ClothID).material;
        mrBall.material = Game.Instance.m_staticData.GetFootballInfo(gm.TakeOnFootball).material;
    }
}
