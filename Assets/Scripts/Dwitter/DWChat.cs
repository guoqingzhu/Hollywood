using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWChat : MonoBehaviour
{
    public GameObject headIcon;
    public GameObject inputField;
    public GameObject chatBox; //������Ϣ
    public GameObject chatContent;// ��Ϣ���ڵ�

    /// <summary>
    /// ��ʼ���������
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
