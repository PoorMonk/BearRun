using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : ReusableObject
{
    public float showTime = 1f;

    public override void OnSpawn()
    {
        StartCoroutine(DestroyCoroutine());
    }

    public override void OnUpSpawn()
    {
        StopAllCoroutines();
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(showTime);
        Game.Instance.m_objectPool.UnSpawn(gameObject);
    }
}
