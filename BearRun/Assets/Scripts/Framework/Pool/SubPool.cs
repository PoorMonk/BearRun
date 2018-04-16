using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class SubPool
{
    List<GameObject> m_objects = new List<GameObject>();
    GameObject m_prefab;
    public string Name
    {
        get { return m_prefab.name; }
    }

    Transform m_parent;

    public SubPool(Transform parent, GameObject go)
    {
        m_parent = parent;
        m_prefab = go;
    }

    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (GameObject obj in m_objects)
        {
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }
        if (go == null)
        {
            go = GameObject.Instantiate(m_prefab);
            go.transform.parent = m_parent;
            m_objects.Add(go);
        }
        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        return go;
    }

    public void UnSpawn(GameObject go)
    {
        if (IsContained(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    public void UnSpawnAll()
    {
        foreach (var obj in m_objects)
        {
            if(obj.activeSelf)
                UnSpawn(obj);
        }
    }

    public bool IsContained(GameObject go)
    {
        return m_objects.Contains(go);
    }
}

