using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class MVC
{
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();

    public static void RegisterView(View view)
    {
        view.RegisterAttentionEvent();
        Views[view.Name] = view;
    }

    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    public static void RegisterController(string eventName, Type controllerType)
    {
        CommandMap[eventName] = controllerType;
    }

    public static T GetModel<T>() where T : Model
    {
        foreach (var m in Models.Values)
        {
            if (m is T)
                return (T)m;
        }
        return null;
    }

    public static T GetView<T>() where T : View
    {
        foreach (var m in Views.Values)
        {
            if (m is T)
                return (T)m;
        }
        return null;
    }

    public static void SendEvent(string eventName, object data = null)
    {
        if (CommandMap.ContainsKey(eventName))
        {
            Type t = CommandMap[eventName];
            Controller c = Activator.CreateInstance(t) as Controller; //控制器生成
            c.Execute(data);
        }

        foreach (var v in Views.Values)
        {
            if (v.AttentionList.Contains(eventName))
            {
                v.HandleEvent(eventName, data);
            }
        }
    }
}

