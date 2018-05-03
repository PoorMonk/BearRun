using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticData : MonoSingleton<StaticData> {

    public List<Material> footballMaterial = new List<Material>();
    Dictionary<int, FootballInfo> dicFootballInfo = new Dictionary<int, FootballInfo>();

    public List<Material> m_playerCloth;
    Dictionary<int, Dictionary<int, FootballInfo> > m_playerClothData = new Dictionary<int, Dictionary<int, FootballInfo> >();


    protected override void Awake()
    {
        base.Awake();
        InitFootball();
        InitPlayerCloth();
    }

    void InitFootball()
    {
        dicFootballInfo.Add(0, new FootballInfo { material = footballMaterial[0], coin = 0 });
        dicFootballInfo.Add(1, new FootballInfo { material = footballMaterial[1], coin = 200 });
        dicFootballInfo.Add(2, new FootballInfo { material = footballMaterial[2], coin = 400 });
    }

    void InitPlayerCloth()
    {
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; j++)
            {
                if (!m_playerClothData.ContainsKey(i))
                {
                    m_playerClothData.Add(i, new Dictionary<int, FootballInfo>());
                }
                m_playerClothData[i].Add(j, new FootballInfo { coin = j * 200, material = m_playerCloth[i * 3 + j] });
                //Debug.Log("****" + m_playerClothData[i][j].coin);
            }
        }
    }

    public FootballInfo GetFootballInfo(int i)
    {
        return dicFootballInfo[i];
    }

    public FootballInfo GetPlayerInfo(int i, int j)
    {
        return m_playerClothData[i][j];
    }
}
