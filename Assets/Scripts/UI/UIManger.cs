using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制场景内的UI显示
public class UIManger : MonoBehaviour
{

    private static UIManger _instance;

    private string originPath = "Prefabs/UI/";
    private string chatBoxName = "ChatBox";
    private string chooseBoxName = "ChooseBox";

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
    public void showChatBox(Transform parent, string content, ChatBox.CallBack cb = null)
    {
        var gameObject = LoadGameObject(chatBoxName);
        var box = Instantiate(gameObject, parent);
        box.GetComponent<ChatBox>().InitChatBox(content, cb);
    }

    //ArrayList aa = new ArrayList();
    //aa.Add("1111");
    //UIManger.GetInstance().showChooseBox(transform, aa);
    /// <summary>
    /// 显示n个选项
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="items"></param>
    public void showChooseBox(Transform parent, ArrayList items)
    {
        var gameObject = LoadGameObject(chooseBoxName);
        var box = Instantiate(gameObject, parent);
        box.GetComponent<ChooseBox>().InitChooseBox(items);
    }
}
