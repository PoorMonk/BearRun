using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    public MeshRenderer m_ballMeshRenderer;
    public int m_selectIndex = 0;

    public Image m_imgFootball;
    public Sprite m_spEquip;
    public Sprite m_spBuy;
    public Sprite m_gizmoBuy;
    public Sprite m_gizmoUnbuy;
    public Sprite m_gizmoEquip;

    public List<Image> m_footballGizmo = new List<Image>();

    GameModel gm;
    public ItemState m_state;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Consts.V_UIShop;
        }
    }
    #endregion

    #region 方法
    public void OnFirstBallClicked()
    {
        m_selectIndex = 0;
        m_ballMeshRenderer.material = Game.Instance.m_staticData.GetFootballInfo(m_selectIndex).material;
        UpdateFootballBuyBtn(m_selectIndex);
    }

    public void OnSecondBallClicked()
    {
        m_selectIndex = 1;
        m_ballMeshRenderer.material = Game.Instance.m_staticData.GetFootballInfo(m_selectIndex).material;
        UpdateFootballBuyBtn(m_selectIndex);
    }

    public void OnThirdBallClicked()
    {
        m_selectIndex = 2;
        m_ballMeshRenderer.material = Game.Instance.m_staticData.GetFootballInfo(m_selectIndex).material;
        UpdateFootballBuyBtn(m_selectIndex);
    }

    public void UpdateFootballBuyBtn(int i)
    {
        m_state = gm.GetSkinState(i);
        switch (m_state)
        {
            case ItemState.BUY:
                m_imgFootball.sprite = m_spEquip;
                m_imgFootball.transform.gameObject.SetActive(true);
                break;
            case ItemState.UNBUY:
                m_imgFootball.sprite = m_spBuy;
                m_imgFootball.transform.gameObject.SetActive(true);
                break;
            case ItemState.EQUIP:
                m_imgFootball.transform.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void UpdataFootballGizmo()
    {
        for (int i = 0; i < 3; ++i)
        {
            m_state = gm.GetSkinState(i);
            switch (m_state)
            {
                case ItemState.BUY:
                    m_footballGizmo[i].sprite = m_gizmoBuy;
                    break;
                case ItemState.UNBUY:
                    m_footballGizmo[i].sprite = m_gizmoUnbuy;
                    break;
                case ItemState.EQUIP:
                    m_footballGizmo[i].sprite = m_gizmoEquip;
                    break;
                default:
                    break;
            }
        }
        
    }

    public void OnbtnFootballBuyClicked()
    {
        BuyFootballArgs e = new BuyFootballArgs
        {
            coin = Game.Instance.m_staticData.GetFootballInfo(m_selectIndex).coin,
            index = m_selectIndex
        };
        switch (gm.GetSkinState(m_selectIndex))
        {
            case ItemState.BUY:
                SendEvent(Consts.E_EquipFootball, e);
                break;
            case ItemState.UNBUY:
                
                SendEvent(Consts.E_BuyFootball, e);
                break;
            case ItemState.EQUIP:
                break;
            default:
                break;
        }
    }
    #endregion

    #region Unity回调
    private void Awake()
    {
        gm = GetModel<GameModel>();
    }
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {

    }
    #endregion

    #region 帮助方法
    #endregion




}
