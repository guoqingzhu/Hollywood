using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 控制场景内的UI显示
public class UIManger : MonoBehaviour
{

    private static UIManger _instance;

    private string originPath = "Prefabs/UI/";
    private string actoriginPath = "Prefabs/Actor/";


    private string chatBoxName = "ChatBox";
    private string chooseBoxName = "ChooseBox";
    private string actChatBoxName = "ActChatBox";
    private string loading = "Loading";

    private string shootingScene = "shootingScene";


    public static UIManger GetInstance()
    {
        return _instance ?? (_instance = new UIManger());
    }


    // 根据名字加载UIobject
    private GameObject LoadGameObject(string objName)
    {
        GameObject obj = Resources.Load<GameObject>(originPath + objName);
        if (obj != null)
        {
            return obj;
        }
        else return null;
    }

    /// <summary>
    ///  显示一个聊天框
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="content"></param>
    public GameObject showChatBox(Transform parent, string content, ChatBox.CallBack cb = null)
    {
        var gameObject = LoadGameObject(chatBoxName);
        var box = Instantiate(gameObject, parent);
        box.GetComponent<ChatBox>().InitChatBox(content, cb);
        return box;
    }

    //ArrayList aa = new ArrayList();
    //aa.Add("1111");
    //UIManger.GetInstance().showChooseBox(transform, aa);
    /// <summary>
    /// 显示n个选项
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="items"></param>
    public GameObject showChooseBox(Transform parent, List<ChooseInfo> items)
    {
        var gameObject = LoadGameObject(chooseBoxName);
        var box = Instantiate(gameObject, parent);
        box.GetComponent<ChooseBox>().InitChooseBox(items);
        return box;
    }


    public GameObject showActChatBox(Transform parent, string actName, string msg, ActChatBox.CallBack cb = null)
    {
        var gameObject = LoadGameObject(actChatBoxName);
        var box = Instantiate(gameObject, parent);
        //Texture2D actImage = Resources.Load<Texture2D>(actoriginPath + actName);
        box.GetComponent<ActChatBox>().InitChatBox(actName, null, msg, cb);
        return box;
    }

    /// <summary>
    /// 显示加载。。。
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject showLoading(Transform parent)
    {
        var gameObject = LoadGameObject(loading);
        var box = Instantiate(gameObject, parent);
        return box;
    }

    public GameObject ShowShootingScene(Transform parent)
    {
        var gameObject = LoadGameObject(shootingScene);
        var node = Instantiate(gameObject, parent);
        return node;
    }
}
