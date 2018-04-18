using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : ReusableObject
{
    Transform m_parent;

    public override void OnSpawn()
    {
        
    }

    public override void OnUpSpawn()
    {
        
    }

    private void Awake()
    {
        m_parent = GameObject.Find("EffectParent").transform;
    }

    public void HitPlayer(Vector3 pos)
    {
        //生成特效
        GameObject go = Game.Instance.m_objectPool.Spawn("FX_ZhuangJi", m_parent);
        go.transform.position = pos;

        //播放声音
        

        //回收
        //Game.Instance.m_objectPool.UnSpawn(gameObject);
        Destroy(gameObject);
    }
}
