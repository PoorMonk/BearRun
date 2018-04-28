using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticData : MonoSingleton<StaticData> {

    public List<Material> footballMaterial = new List<Material>();
    Dictionary<int, FootballInfo> dicFootballInfo = new Dictionary<int, FootballInfo>();

    protected override void Awake()
    {
        base.Awake();
        dicFootballInfo.Add(0, new FootballInfo { material = footballMaterial[0], coin = 0 });
        dicFootballInfo.Add(1, new FootballInfo { material = footballMaterial[1], coin = 200 });
        dicFootballInfo.Add(2, new FootballInfo { material = footballMaterial[2], coin = 400 });
    }

    public FootballInfo GetFootballInfo(int i)
    {
        return dicFootballInfo[i];
    }
}
