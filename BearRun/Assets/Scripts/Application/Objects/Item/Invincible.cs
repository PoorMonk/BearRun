using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : Item
{
    public override void HitPlayer(Transform pos)
    {
        Game.Instance.m_sound.PlayEffect("Se_UI_Whist");

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            HitPlayer(other.transform);
            other.SendMessage("HitInvincible", SendMessageOptions.RequireReceiver);
        }
    }
}
