using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGoal : ReusableObject
{
    public Animation m_goalKeeper;
    public Animation m_door;
    public GameObject m_net;

    public float m_speed = 10f;
    bool m_isFly = false;

    public override void OnSpawn()
    {
        
    }

    public override void OnUpSpawn()
    {
        Debug.Log("ShootGoal OnUpSpawn");
        m_goalKeeper.Play("standard");
        //m_goalKeeper.gameObject.SetActive(true);
        m_goalKeeper.transform.parent.parent.gameObject.SetActive(true);
        m_isFly = false;
        m_door.Play("QiuMen_St");
        m_net.SetActive(true);
        StopAllCoroutines();
        m_goalKeeper.transform.localPosition = Vector3.zero;
    }
    int itest = 0;
    public void GetGoal(int i)
    {
        //m_goalKeeper.gameObject.SetActive(false);
        
        switch(i)
        {
            case -2:
                m_goalKeeper.Play("left_flutter");
                break;
            case 0:
                m_goalKeeper.Play("flutter");
                break;
            case 2:
                m_goalKeeper.Play("right_flutter");
                break;
        }
        itest++;
        Debug.Log("Got it! " + itest);
        StartCoroutine(HideGoalKeeper());
    }

    IEnumerator HideGoalKeeper()
    {
        yield return new WaitForSeconds(0.1f);
        m_goalKeeper.transform.parent.parent.gameObject.SetActive(false);
        Debug.Log("HideGoalKeeper");
    }

    public void HitGoalKeeper()
    {
        m_isFly = true;
        m_goalKeeper.Play("fly");
        
    }

    public void ReInit()
    {
        StartCoroutine(UpSpawnCor());
    }

    //触发踢球5S之后把球门的状态改回初始状态
    IEnumerator UpSpawnCor()
    {
        yield return new WaitForSeconds(5);
        OnUpSpawn();
        //Game.Instance.m_objectPool.UnSpawn(gameObject);
    }

    private void Update()
    {
        if (m_isFly)
        {
            m_goalKeeper.transform.position += new Vector3(0, m_speed, m_speed) * Time.deltaTime;
        }
    }

    public void HitDoor(int i)
    {
        switch (i)
        {
            case 0:
                m_door.Play("QiuMen_RR");
                break;
            case 1:
                m_door.Play("QiuMen_St");
                break;
            case 2:
                m_door.Play("QiuMen_LR");
                break;
        }
        m_net.SetActive(false);
    }
}
