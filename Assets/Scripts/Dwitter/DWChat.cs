using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWChat : MonoBehaviour
{
    public GameObject headIcon;
    public GameObject inputField;
    public GameObject chatBox;

    /// <summary>
    /// ��ʼ���������
    /// </summary>
    /// <param name="data"></param>
    public void initChat(ChatInitData data) { }

    public void OnClickSend()
    {
        inputField.GetComponent<TMP_InputField>().text = "";
    }

    public void OnClickBack()
    {
        Destroy(gameObject);
    }
}
