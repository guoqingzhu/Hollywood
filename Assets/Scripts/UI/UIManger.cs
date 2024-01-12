using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ƴ����ڵ�UI��ʾ
public class UIManger : MonoBehaviour
{

    private static UIManger _instance;

    private string originPath = "Prefabs/UI/";
    private string chatBoxName = "ChatBox";
    private string chooseBoxName = "ChooseBox";
    private string actChatBoxName = "ActChatBox";



    public static UIManger GetInstance()
    {
        return _instance ?? (_instance = new UIManger());
    }


    // �������ּ���UIobject
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
    ///  ��ʾһ�������
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
    /// ��ʾn��ѡ��
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
        box.GetComponent<ActChatBox>().InitChatBox(actName, msg, cb);
        return box;
    }
}
