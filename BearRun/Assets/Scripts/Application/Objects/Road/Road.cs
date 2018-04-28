using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : ReusableObject
{
    public override void OnSpawn()
    {
        
    }

    public override void OnUpSpawn()
    {
        //回收Item下的东西
        var itemChild = transform.Find("Item");
        if (itemChild != null)
        {
            foreach (Transform child in itemChild)
            {
                if (child != null)
                {
                    Game.Instance.m_objectPool.UnSpawn(child.gameObject);
                }
            }
        }
    }
}
