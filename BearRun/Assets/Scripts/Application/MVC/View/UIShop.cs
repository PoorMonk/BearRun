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
    public Image m_imgSkin;
    public Image m_imgCloth;
    public Sprite m_spEquip;
    public Sprite m_spBuy;
    public Sprite m_gizmoBuy;
    public Sprite m_gizmoUnbuy;
    public Sprite m_gizmoEquip;
    public List<Sprite> m_headList;
    public Text m_textMoney;
    public Text m_textName;
    public Image m_imgHead;
    public Text m_textGrad;

    public List<Image> m_footballGizmo = new List<Image>();
    public List<Image> m_clothGizmo = new List<Image>();
    public List<Image> m_skinGizmo = new List<Image>();

    GameModel gm;
    public ItemState m_state;

    public SkinnedMeshRenderer m_playerMeshRenderer;
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

    #region 足球
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
        m_state = gm.GetFootballState(i);
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
            m_state = gm.GetFootballState(i);
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
        switch (gm.GetFootballState(m_selectIndex))
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

    #region 皮肤
    public void OnMomoSkin()
    {
        m_selectIndex = 0;
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(0, gm.TakeOnSkin.ClothID).material;
        UpdateSkinBuybtn(m_selectIndex);
        Game.Instance.m_sound.PlayEffect("Se_UI_Dress");
    }

    public void OnSaliSkin()
    {
        m_selectIndex = 1;
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(1, gm.TakeOnSkin.ClothID).material;
        UpdateSkinBuybtn(m_selectIndex);
        Game.Instance.m_sound.PlayEffect("Se_UI_Dress");
    }

    public void OnSugarSkin()
    {
        m_selectIndex = 2;
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(2, gm.TakeOnSkin.ClothID).material;
        UpdateSkinBuybtn(m_selectIndex);
        Game.Instance.m_sound.PlayEffect("Se_UI_Dress");
    }

    public void UpdateSkinBuybtn(int i)
    {
        m_state = gm.GetSkinState(i);
        UpdateBuyBtn(m_state, m_imgSkin);
    }

    public void UpdateBuyBtn(ItemState state, Image image)
    {       
        switch (state)
        {
            case ItemState.BUY:
                image.sprite = m_spEquip;
                image.transform.gameObject.SetActive(true);
                break;
            case ItemState.UNBUY:
                image.sprite = m_spBuy;
                image.transform.gameObject.SetActive(true);
                break;
            case ItemState.EQUIP:
                image.transform.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void OnbtnSkinClicked()
    {
        SkinIndex index = new SkinIndex
        {
            SkinID = m_selectIndex,
            ClothID = gm.TakeOnSkin.ClothID
        };
        BuySkinClothArgs e = new BuySkinClothArgs
        {
            skinIndex = index,
            coin = Game.Instance.m_staticData.GetPlayerInfo(0, m_selectIndex).coin
        };
        ItemState state = gm.GetSkinState(m_selectIndex);
        btnClicked(state, e);
        UpdateSkinBuybtn(e.skinIndex.SkinID);
        UpdateSkinGizmo();
    }

    #region 公共接口
    private ItemState GetState(int i, ItemBuy kind)
    {
        ItemState state = ItemState.UNBUY;
        switch (kind)
        {
            case ItemBuy.SKIN:
                state = gm.GetSkinState(i);
                break;
            case ItemBuy.CLOTH:
                state = gm.GetClothState(new SkinIndex { SkinID = gm.TakeOnSkin.SkinID, ClothID = i });
                break;
            case ItemBuy.BALL:
                break;
            case ItemBuy.SHOES:
                break;
        }
        return state;
    }

    private void UpdateGizmo(List<Image> images, ItemBuy kind)
    {
        for (int i = 0; i < 3; ++i)
        {           
            switch (GetState(i, kind))
            {
                case ItemState.BUY:
                    images[i].sprite = m_gizmoBuy;
                    break;
                case ItemState.UNBUY:
                    images[i].sprite = m_gizmoUnbuy;
                    break;
                case ItemState.EQUIP:
                    images[i].sprite = m_gizmoEquip;
                    break;
                default:
                    break;
            }
        }
    }

    private void btnClicked(ItemState state, BuySkinClothArgs e)
    {
        switch (state)
        {
            case ItemState.BUY:
                SendEvent(Consts.E_EquipSkin, e);
                break;
            case ItemState.UNBUY:
                SendEvent(Consts.E_BuySkinCloth, e);
                break;
            case ItemState.EQUIP:
                break;
            default:
                break;
        }
    }
    #endregion

    public void UpdateSkinGizmo()
    {
        m_state = gm.GetSkinState(m_selectIndex);
        UpdateGizmo(m_skinGizmo, ItemBuy.SKIN);
    }

    public void UpdateClothGizmo()
    {
        m_state = gm.GetClothState(new SkinIndex { SkinID = gm.TakeOnSkin.SkinID, ClothID = m_selectIndex });
        UpdateGizmo(m_clothGizmo, ItemBuy.CLOTH);
    }

    public void OnbtnClothClicked()
    {
        SkinIndex index = new SkinIndex
        {
            SkinID = gm.TakeOnSkin.SkinID,
            ClothID = m_selectIndex
        };
        BuySkinClothArgs e = new BuySkinClothArgs
        {
            skinIndex = index,
            coin = Game.Instance.m_staticData.GetPlayerInfo(index.SkinID, m_selectIndex).coin
            
        };
        Debug.Log("----" + e.coin);
        ItemState state = gm.GetClothState(index);
        btnClicked(state, e);
        UpdateClothBuybtn(index);
        UpdateClothGizmo();
    }

    public void UpdateClothBuybtn(SkinIndex index)
    {
        ItemState state = gm.GetClothState(index);
        UpdateBuyBtn(state, m_imgCloth);
    }

    public void OnbtnDefaultCloth()
    {
        m_selectIndex = 0;
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, m_selectIndex).material;
        UpdateClothBuybtn(new SkinIndex { SkinID = gm.TakeOnSkin.SkinID, ClothID = m_selectIndex});
        Game.Instance.m_sound.PlayEffect("Se_UI_Dress");
    }

    public void OnbtnBrazilCloth()
    {
        m_selectIndex = 2;
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, m_selectIndex).material;
        UpdateClothBuybtn(new SkinIndex { SkinID = gm.TakeOnSkin.SkinID, ClothID = m_selectIndex });
        Game.Instance.m_sound.PlayEffect("Se_UI_Dress");
    }

    public void OnbtnAgtCloth()
    {
        m_selectIndex = 1;
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, m_selectIndex).material;
        UpdateClothBuybtn(new SkinIndex { SkinID = gm.TakeOnSkin.SkinID, ClothID = m_selectIndex });
        Game.Instance.m_sound.PlayEffect("Se_UI_Dress"); 
            
    }


    #endregion

    #region 换肤分组点击
    public void OnRoleGroupClicked()
    {
        
        //UpdateClothBuybtn(gm.TakeOnSkin);
        //Debug.Log("click:" + gm.TakeOnSkin.SkinID + ", " + gm.TakeOnSkin.ClothID);
        //UpdateSkinBuybtn(gm.TakeOnSkin.SkinID);
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, gm.TakeOnSkin.ClothID).material;
        m_ballMeshRenderer.material = Game.Instance.m_staticData.GetFootballInfo(gm.TakeOnFootball).material;
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnClothGroupClicked()
    {
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, gm.TakeOnSkin.ClothID).material;
        m_ballMeshRenderer.material = Game.Instance.m_staticData.GetFootballInfo(gm.TakeOnFootball).material;
        Debug.Log("click:" + gm.TakeOnSkin.SkinID + ", " + gm.TakeOnSkin.ClothID);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnShoesGroupClicked()
    {
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, gm.TakeOnSkin.ClothID).material;
        m_ballMeshRenderer.material = Game.Instance.m_staticData.GetFootballInfo(gm.TakeOnFootball).material;
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnFootballGroupClicked()
    {
        m_playerMeshRenderer.material = Game.Instance.m_staticData.GetPlayerInfo(gm.TakeOnSkin.SkinID, gm.TakeOnSkin.ClothID).material;
        m_ballMeshRenderer.material = Game.Instance.m_staticData.GetFootballInfo(gm.TakeOnFootball).material;
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }
    #endregion

    public void UpdateUI()
    {
        m_textMoney.text = gm.Coin.ToString();
        Debug.Log("money:" + gm.Coin);
        switch (gm.TakeOnSkin.SkinID)
        {
            case 0:
                m_textName.text = "莫莫";
                break;
            case 1:
                m_textName.text = "SaLi";
                break;
            case 2:
                m_textName.text = "Sugar";
                break;
        }
        m_imgHead.sprite = m_headList[gm.TakeOnSkin.SkinID];
    }

    public void OnbtnStartGameClicked()
    {
        Game.Instance.LoadLevel(3);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }

    public void OnbtnReturnClicked()
    {
        if (gm.lastIndex == 4)
            gm.lastIndex = 1;
        Game.Instance.LoadLevel(gm.lastIndex);
        Game.Instance.m_sound.PlayEffect("Se_UI_Button");
    }
    #endregion

    #region Unity回调
    private void Awake()
    {       
        gm = GetModel<GameModel>();
        UpdateSkinGizmo();
        m_textGrad.text = gm.Grade.ToString();
        UpdateUI();
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
