using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChange : MonoBehaviour {

    private GameObject m_roadNow;
    private GameObject m_roadNext;
    private GameObject m_parent = null;

	// Use this for initialization
	void Start () {
		if (m_parent == null)
        {
            m_parent = new GameObject();
            m_parent.transform.position = Vector3.zero;
            m_parent.name = "road";
        }
       
        m_roadNow = Game.Instance.m_objectPool.Spawn("Pattern_1", m_parent.transform);
        m_roadNext = Game.Instance.m_objectPool.Spawn("Pattern_2", m_parent.transform);
        m_roadNext.transform.position += new Vector3(0, 0, 160);
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
        int index = Random.Range(1, 5);
        string name = "Pattern_" + index;
        m_roadNext = Game.Instance.m_objectPool.Spawn(name, m_parent.transform);
        m_roadNext.transform.position = m_roadNow.transform.position + new Vector3(0, 0, 160);
    }
}
