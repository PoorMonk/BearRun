using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Sound))]
[RequireComponent(typeof(StaticData))]
public class Game : MonoSingleton<Game> {

    [HideInInspector] public ObjectPool m_objectPool;
    [HideInInspector] public Sound m_sound;
    [HideInInspector] public StaticData m_staticData;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        m_objectPool = ObjectPool.Instance;
        m_sound = Sound.Instance;
        m_staticData = StaticData.Instance;        

        //初始化 注册
        RegisterController(Consts.E_StartUp, typeof(StartUpController));

        //游戏启动
        SendEvent(Consts.E_StartUp);

        //跳转场景
        LoadLevel(4);
    }

    void LoadLevel(int level)
    {
        //退出当前场景
        SceneArgs s = new SceneArgs() {
            sceneIndex = SceneManager.GetActiveScene().buildIndex
        };

        SendEvent(Consts.E_ExitEvent, s);

        //进入新场景
        SceneManager.LoadScene(level);
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("Enter scene: " + level);
        SceneArgs s = new SceneArgs() {
            sceneIndex = level
        };
        SendEvent(Consts.E_EnterEvent, s);
    }

    void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}
