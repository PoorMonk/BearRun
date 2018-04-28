using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChange : MonoBehaviour {

    private GameObject m_roadNow;
    private GameObject m_roadNext;
    private GameObject m_parent = null;

    //private GameObject[] m_roadAll = new GameObject[4];

	// Use this for initialization
	void Start () {
		if (m_parent == null)
        {
            m_parent = new GameObject();
            m_parent.transform.position = Vector3.zero;
            m_parent.name = "road";
        }

        //for (int i  = 0; i < m_roadAll.Length; ++i)
        //{
        //    m_roadAll[i] = Game.Instance.m_objectPool.Spawn("Pattern_" + (i + 1).ToString(), m_parent.transform);
        //    AddItem(m_roadAll[i]);
        //    m_roadAll[i].SetActive(false);
        //}

        m_roadNow = Game.Instance.m_objectPool.Spawn("Pattern_1", m_parent.transform);
        m_roadNext = Game.Instance.m_objectPool.Spawn("Pattern_2", m_parent.transform);
        //m_roadNext = Game.Instance.m_objectPool.Spawn("Pattern_1", m_parent.transform); //wait delete
        //m_roadNow = m_roadAll[0];
        //m_roadNext = m_roadAll[0];
        m_roadNext.transform.position += new Vector3(0, 0, 160);
        //m_roadNow.SetActive(true);
        //m_roadNext.SetActive(true);
        AddItem(m_roadNow);
        AddItem(m_roadNext);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.road)
        {
            Game.Instance.m_objectPool.UnSpawn(other.gameObject);
            SpawnNewRoad();
        }
    }

    private void SpawnNewRoad()
    {
        m_roadNow = m_roadNext;
        //int index = 1; //wait delete
        int index = Random.Range(1, 5);
        string name = "Pattern_" + index;
        m_roadNext = Game.Instance.m_objectPool.Spawn(name, m_parent.transform);
        m_roadNext.transform.position = m_roadNow.transform.position + new Vector3(0, 0, 160);
        AddItem(m_roadNext);
    }

    public void AddItem(GameObject obj)
    {
        var itemChild = obj.transform.Find("Item");
        if (itemChild != null && itemChild.childCount == 0) //如果Item下已经有物体了，就不要重复添加了（或者先把原来的清除，再生成新的）
        {
            var patternManager = PatternManager.Instance;
            if (patternManager != null && patternManager.patterns != null && patternManager.patterns.Count > 0)
            {
                //随机取一个方案
                var pattern = patternManager.patterns[Random.Range(0, patternManager.patterns.Count)];
                if (pattern != null && pattern.patternItems != null && pattern.patternItems.Count > 0)
                {
                    foreach (var item in pattern.patternItems)
                    {
                        GameObject go = Game.Instance.m_objectPool.Spawn(item.prefabName, itemChild);
                        go.transform.parent = itemChild;
                        go.transform.localPosition = item.pos;
                    }
                }
            }
        }
    }
}
