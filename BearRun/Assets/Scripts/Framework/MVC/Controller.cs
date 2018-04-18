using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Controller{

    public abstract void Execute(object data);

    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>() as T;
    }

    protected T GetView<T>() where T : View
    {
        return MVC.GetView<T>() as T;
    }

    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }

    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }

    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}
