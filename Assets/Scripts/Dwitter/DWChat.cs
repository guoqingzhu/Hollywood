using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        if (inputField.GetComponent<TMP_InputField>().text == "") return;
        GameObject one = Instantiate(chatBox, chatContent.transform);
        one.GetComponent<DWChatItem>().initContent(inputField.GetComponent<TMP_InputField>().text);
        Color color;
        ColorUtility.TryParseHtmlString("#8e80ef", out color);
        one.transform.GetChild(0).GetComponent<Image>().color = color;
        inputField.GetComponent<TMP_InputField>().text = "";
        //
        RectTransform rectTransform = one.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(1, 0.5f); // ������Сê��Ϊ��Ļ���½�
        rectTransform.anchorMax = new Vector2(1, 0.5f); // �������ê��Ϊ��Ļ���Ͻ�
        rectTransform.pivot = new Vector2(0.5f, 0.5f); // �������ĵ�Ϊ�ڵ���Ҳ�����

        LayoutRebuilder.ForceRebuildLayoutImmediate(one.GetComponent<DWChatItem>().content.rectTransform);
        var height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
        var width = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.width;

        if (width > 500)
        {
            width = 450;
            var content = one.GetComponent<DWChatItem>().content;
            content.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.rectTransform);
            height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(500, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);

        }
        else
        {

            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(width + 50, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);
        }

        rectTransform.anchoredPosition = new Vector2(-(width + 50) / 2, 0);

    }


    public void GetMessage(string text)
    {
        if (text == null || text == "") return;
        GameObject one = Instantiate(chatBox, chatContent.transform);
        one.GetComponent<DWChatItem>().initContent(text);
        //
        RectTransform rectTransform = one.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0.5f);
        rectTransform.anchorMax = new Vector2(0, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        LayoutRebuilder.ForceRebuildLayoutImmediate(one.GetComponent<DWChatItem>().content.rectTransform);
        var height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
        var width = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.width;

        if (width > 500)
        {
            width = 450;
            var content = one.GetComponent<DWChatItem>().content;
            content.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.rectTransform);
            height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(500, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);

        }
        else
        {
            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(width + 50, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);
        }

        rectTransform.anchoredPosition = new Vector2((width + 100) / 2, 0);
    }


    public void OnClickBack()
    {
        Destroy(gameObject);
    }
}
