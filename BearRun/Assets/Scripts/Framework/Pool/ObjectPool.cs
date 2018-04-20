using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool> {

    /// <summary>
    /// 资源目录
    /// </summary>
    public string ResourceDir = "";

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();

    public GameObject Spawn(string name, Transform trans)
    {
        SubPool pool = null;
        if (!m_pools.ContainsKey(name))
        {
            CreateNewPool(name, trans);
        }
        pool = m_pools[name];
        return pool.Spawn();
    }

    public void UnSpawn(GameObject go)
    {
        SubPool pool = null;
        foreach (var pl in m_pools.Values)
        {
            if (pl.IsContained(go))
            {
                pool = pl;
                break;
            }
        }
        if (pool == null)
            print("pool is null" + go.name);
        pool.UnSpawn(go);
    }

    public void UnSpawnAll()
    {
        foreach (var p in m_pools.Values)
        {
            p.UnSpawnAll();
        }
    }

    private void CreateNewPool(string names, Transform trans)
    {
        string path = ResourceDir + "/" + names;
        GameObject go = Resources.Load<GameObject>(path);
        SubPool pool = new SubPool(trans, go);
        m_pools.Add(pool.Name, pool);
        Debug.Log("CreatePool" + pool.Name);
    }
	
}
