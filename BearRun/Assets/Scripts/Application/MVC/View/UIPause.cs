using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : View
{
    public Text textDis;
    public Text textScore;
    public Text textCoin;

    GameModel m_gameModel;    
    public SkinnedMeshRenderer skm;
    public MeshRenderer mrBall;

    public override string Name
    {
        get
        {
            return Consts.V_UIPause;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    public void OnResumeClicked()
    {
        Hide();
        SendEvent(Consts.E_ResumeGame);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnHomeClicked()
    {
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
        Game.Instance.LoadLevel(1);
    }

    private void Awake()
    {
        m_gameModel = GetModel<GameModel>();
        skm.material = Game.Instance.m_staticData.GetPlayerInfo(m_gameModel.TakeOnSkin.SkinID, m_gameModel.TakeOnSkin.ClothID).material;
        mrBall.material = Game.Instance.m_staticData.GetFootballInfo(m_gameModel.TakeOnFootball).material;
    }
}
