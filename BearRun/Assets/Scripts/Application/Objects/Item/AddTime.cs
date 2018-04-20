using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : Item
{
    public override void HitPlayer(Transform pos)
    {
        Game.Instance.m_sound.PlayEffect("Se_UI_Time");

        //Game.Instance.m_objectPool.UnSpawn(gameObject);
        Destroy(gameObject);
    }
        

    public override void OnSpawn()
    {
        
    }

    public override void OnUpSpawn()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            HitPlayer(other.transform);
            other.SendMessage("HitAddTime", SendMessageOptions.RequireReceiver);
        }
    }
}
