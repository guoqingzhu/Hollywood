using System.Collections.Generic;
using UnityEngine;

public class EventManger
{
    private static EventManger _instance;

    public delegate void CallBack(EventData data);

    private readonly Dictionary<string, CallBack> dicHandler;
    private readonly Dictionary<string, EventData> dicEventDatas;

    private EventManger()
    {
        dicHandler = new Dictionary<string, CallBack>();
        dicEventDatas = new Dictionary<string, EventData>();
    }


    public static EventManger GetInstance()
    {
        return _instance ?? (_instance = new EventManger());
    }

    // 注册监听
    public void AddEventListener(string type, CallBack callBack, EventData data = null)
    {
        if (!dicHandler.ContainsKey(type))
        {
            dicHandler.Add(type, callBack);
            dicEventDatas.Add(type, data);
        }

        dicHandler[type] = callBack;
    }

    // 移除某种类型的监听
    public void RemoveEventListener(string type)
    {
        if (dicHandler.ContainsKey(type))
        {
            dicHandler.Remove(type);
        }
    }

    public void RemoveAllListener()
    {
        dicHandler.Clear();
    }

    // 移除所有监听事件
    public void ClearEventListener()
    {
        dicHandler?.Clear();
    }


    // 派发事件
    public void DispachEvent(string type)
    {
        if (!dicHandler.ContainsKey(type))
        {
            return;
        }

        CallBack callBack = dicHandler[type];
        EventData data = dicEventDatas[type];
        callBack(data);
    }
}