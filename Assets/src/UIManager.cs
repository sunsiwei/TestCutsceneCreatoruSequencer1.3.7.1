using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UIManager {

    private Dictionary<Type, string> uiMap;
    private Dictionary<Type, GameObject> uiObjMap;

    public void InitUIMap()
    {
        RegisterUI(typeof(UILogin), "UILogin");
        RegisterUI(typeof(UILoginReply), "UILoginReply");
    }

    private void RegisterUI(Type component, string path)
    {
        if (uiMap == null)
        {
            uiMap = new Dictionary<Type, string>();
        }
        uiMap.Add(component, path);
    }

    public T ShowUI<T>()where T : Component
    {
        string path = uiMap[typeof(T)];
        GameObject ui = GameObject.Instantiate(LoadUI(path)) as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        ui.transform.SetParent(canvas.transform, false);

        if (uiObjMap == null)
            uiObjMap = new Dictionary<Type, GameObject>();
        if (uiObjMap.ContainsKey(typeof(T)) != true)
            uiObjMap.Add(typeof(T), ui);

        return ui.GetComponent<T>();
    }

    public void HideUI<T>() where T : Component
    {
        if (uiObjMap.ContainsKey(typeof(T)) == true)
        {
            GameObject ui = uiObjMap[typeof(T)];
            UnityEngine.GameObject.Destroy(ui);
            uiObjMap.Remove(typeof(T));
        }
    }

    GameObject LoadUI(string path)
    {
        return Resources.Load(path) as GameObject;
    }

    protected UIManager() { }

    private static UIManager instance;
    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            instance = new UIManager();
            instance.InitUIMap();
            return instance;
        }
        else
            return instance;
    }
}
