using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Effects
{
    public override void OnSpawn()
    {
        transform.localPosition = new Vector3(0, 0, 4.29f);
        transform.localScale = 3.33f * Vector3.one;
        base.OnSpawn();
    }

    public override void OnUpSpawn()
    {
        base.OnUpSpawn();
    }
}
