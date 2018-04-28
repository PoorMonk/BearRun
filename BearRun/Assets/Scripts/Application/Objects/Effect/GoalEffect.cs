using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : Effects
{
    public override void OnSpawn()
    {
        transform.localPosition = new Vector3(0, 14.05f, -19.08f);
        base.OnSpawn();
    }

    public override void OnUpSpawn()
    {
        base.OnUpSpawn();
    }
}
