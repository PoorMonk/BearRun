using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Obstacles
{
    private bool m_isHit = false;
    private bool m_isFly = false;
    private float m_speed = 10f;

    private Animation m_anim;

    public override void OnSpawn()
    {
        base.OnSpawn();
        m_anim.Play("run");
    }

    public override void OnUpSpawn()
    {
        base.OnUpSpawn();
        m_anim.transform.localPosition = Vector3.zero;
        m_isHit = false;
        m_isFly = false;
    }

    protected override void Awake()
    {
        base.Awake();
        m_anim = GetComponentInChildren<Animation>();
        
    }

    protected override void HitPlayer(Vector3 pos)
    {
        GameObject go = Game.Instance.m_objectPool.Spawn("FX_ZhuangJi", m_parent);
        go.transform.position = pos;
        m_isHit = false;
        m_isFly = true;
        m_anim.Play("fly");
    }

    public void HitTrigger()
    {
        m_isHit = true;
    }

    private void Update()
    {
        if (m_isHit)
        {
            transform.position -= new Vector3(m_speed, 0, 0) * Time.deltaTime;
        }
        if (m_isFly)
        {
            transform.position += new Vector3(0, m_speed, m_speed) * Time.deltaTime;
        }
    }

    
}
