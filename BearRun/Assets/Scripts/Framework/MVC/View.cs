using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class View : MonoBehaviour {

	public abstract string Name
    {
        get;
    }

    [HideInInspector]
    public List<string> AttentionList = new List<string>();

    public abstract void HandleEvent(string eventName, object data);

    public virtual void RegisterAttentionEvent()
    {

    }

    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>() as T;
    }
}
