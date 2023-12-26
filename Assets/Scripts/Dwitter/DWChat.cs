using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWChat : MonoBehaviour
{
    public GameObject headIcon;
    public GameObject inputField;
    public GameObject chatBox; //单条消息
    public GameObject chatContent;// 消息父节点

    /// <summary>
    /// 初始化聊天界面
    /// </summary>
    /// <param name="data"></param>
    public void initChat(ChatInitData data) { }

    public void OnClickSend()
    {
        GameObject one = Instantiate(chatBox, chatContent.transform);
        one.GetComponent<DWChatItem>().initContent(inputField.GetComponent<TMP_InputField>().text);
        inputField.GetComponent<TMP_InputField>().text = "";
    }

    public void OnClickBack()
    {
        Destroy(gameObject);
    }
}
