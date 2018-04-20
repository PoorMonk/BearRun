using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    private Transform m_effectParent;
    public float m_speed = 40f;

    public override void HitPlayer(Transform pos)
    {
        GameObject go = Game.Instance.m_objectPool.Spawn("FX_JinBi", m_effectParent);
        go.transform.position = pos.position;

        Game.Instance.m_sound.PlayEffect("Se_UI_JinBi");

        //Game.Instance.m_objectPool.UnSpawn(gameObject);
        Destroy(gameObject);
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUpSpawn()
    {
        base.OnUpSpawn();
    }

    private void Awake()
    {
        m_effectParent = GameObject.Find("EffectParent").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            HitPlayer(other.transform);
            other.SendMessage("EatCoin", SendMessageOptions.RequireReceiver);
        }
        else if (other.tag == Tags.magnetCollider)
        {
            StartCoroutine(HitMagnet(other.transform));
        }
    }

    IEnumerator HitMagnet(Transform pos)
    {
        bool isLoop = true;
        while (isLoop)
        {
            transform.position = Vector3.Lerp(transform.position, pos.position, m_speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pos.position) < 0.5f)
            {
                isLoop = false;
                HitPlayer(pos.transform);
                pos.parent.SendMessage("EatCoin", SendMessageOptions.RequireReceiver);
            }
            yield return 0;
        }
    }
}
