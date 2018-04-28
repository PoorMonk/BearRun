using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Obstacles
{
    private bool m_isHit = false;
    public bool m_canMove = false;
    private float m_speed = 10f;

    GameModel gm;

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUpSpawn()
    {
        m_isHit = false;
        base.OnUpSpawn();
    }

    protected override void Awake()
    {
        gm = MVC.GetModel<GameModel>();
        base.Awake();
    }

    protected override void HitPlayer(Vector3 pos)
    {
        base.HitPlayer(pos);
    }

    public void HitTrigger()
    {
        m_isHit = true;
    }

    private void Update()
    {
        if (m_isHit && m_canMove && gm.IsPlay && !gm.IsPause)
        {
            transform.Translate(-transform.forward * m_speed * Time.deltaTime);
        }
    }
}
