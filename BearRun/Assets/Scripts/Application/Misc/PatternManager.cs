using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatternManager : MonoSingleton<PatternManager> {

    public List<Pattern> patterns = new List<Pattern>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//一个游戏物体的信息
[Serializable]
public class PatternItem
{
    public string prefabName;
    public Vector3 pos;
}


//一套方案
[Serializable]
public class Pattern
{
    public List<PatternItem> patternItems = new List<PatternItem>();
}
