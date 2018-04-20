using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ReusableObject
{
    public float m_rotateSpeed = 60f;

    public override void OnSpawn()
    {
        
    }

    public override void OnUpSpawn()
    {
        transform.localEulerAngles = Vector3.zero;
    }

    private void Update()
    {
        transform.Rotate(0, m_rotateSpeed * Time.deltaTime, 0);
    }

    public virtual void HitPlayer(Transform pos)
    {

    }
}
