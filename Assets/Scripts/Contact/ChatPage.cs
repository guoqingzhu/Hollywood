using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatPage : MonoBehaviour
{
    public GameObject optionsNode;
    public GameObject contant;
    public GameObject chatItem;
    public GameObject headImage;


    private string[] myOptions;


    private string dialogPath = "Data/mia";
    private int curDialigIndex = 1;
    private List<string> dialogs;
    private string curLong = "";

    public void InitChatPage(string name)
    {
        if (name == "Noah")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().noahHead;
        }
        else if (name == "Mia")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().miaHead;
        }
    }



    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void SetOptions(string[] options)
    {
        myOptions = options;
        for (int i = 0; i < options.Length; i++)
        {
            var tt = options[i].Replace("，", ",");
            optionsNode.transform.GetChild(i).GetComponentInChildren<TMP_Text>().text = tt;
        }
    }

    public void onClickOptionA()
    {

        try
        {

            if (curDialigIndex < dialogs.Count - 1)
            {
                OnClickSend(curLong);
                curDialigIndex += 1;
                PlayOne();
            }
            else
            {
                Utils.GetInstance().isLibraryLock = false;
            }
        }
        catch (System.Exception)
        {
            OnClickSend(myOptions[0]);
            throw;
        }

    }


    public void PlayOne()
    {
        dialogs = readCSV.readFile(dialogPath);
        var dialog = dialogs[curDialigIndex].Split(",")[1];
        StartCoroutine(DelayedMethod(0.5f, () =>
        {
            GetMessage(dialog);
            string[] options = new string[1];
            if (curDialigIndex + 1 < dialogs.Count - 1)
            {
                curLong = dialogs[curDialigIndex + 1].Split(",")[1];
                var shortStr = dialogs[curDialigIndex += 1].Split(",")[2];
                options[0] = shortStr;
                SetOptions(options);
            }
        }));
    }

    IEnumerator DelayedMethod(float delayTime, System.Action func)
    {
        yield return new WaitForSeconds(delayTime); // �ȴ�ָ����ʱ��
        func();
    }

    public void ChatWithMia()
    {
        GetMessage("You should go on shooting!!!");
        GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() =>
        {
            Destroy(GameObject.Find("contactScene(Clone)"));
            UIManger.GetInstance().ShowShootingScene(GameObject.Find("Canvas").transform);
        }, "Go on Shooting");
    }

    public void NoahMoney()
    {
        GetMessage("You should make some money");
        GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() =>
        {
            Destroy(GameObject.Find("contactScene(Clone)"));
            Utils.GetInstance().isCafeLock = false;
            UIManger.GetInstance().ShowMapScene(GameObject.Find("Canvas").transform);
        }, "Go to cafe");
    }

    public void GetMessage(string text)
    {
        if (text == null || text == "") return;
        text = text.Replace("，", ",");
        GameObject one = Instantiate(chatItem, contant.transform);
        one.GetComponent<DWChatItem>().initContent(text);
        //
        RectTransform rectTransform = one.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0.5f);
        rectTransform.anchorMax = new Vector2(0, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        LayoutRebuilder.ForceRebuildLayoutImmediate(one.GetComponent<DWChatItem>().content.rectTransform);
        var height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
        var width = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.width;

        if (width > 600)
        {
            width = 550;
            var content = one.GetComponent<DWChatItem>().content;
            content.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.rectTransform);
            height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(620, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);

        }
        else
        {
            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(width + 50, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);
        }

        rectTransform.anchoredPosition = new Vector2((width + 100) / 2, 0);
    }

    public void OnClickSend(string text)
    {
        if (text == null || text == "") return;
        text = text.Replace("，", ",");
        GameObject one = Instantiate(chatItem, contant.transform);
        one.GetComponent<DWChatItem>().initContent(text);
        Color color;
        ColorUtility.TryParseHtmlString("#8e80ef", out color);
        one.transform.GetChild(0).GetComponent<Image>().color = color;
        //
        RectTransform rectTransform = one.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(1, 0.5f); // ������Сê��Ϊ��Ļ���½�
        rectTransform.anchorMax = new Vector2(1, 0.5f); // �������ê��Ϊ��Ļ���Ͻ�
        rectTransform.pivot = new Vector2(0.5f, 0.5f); // �������ĵ�Ϊ�ڵ���Ҳ�����

        LayoutRebuilder.ForceRebuildLayoutImmediate(one.GetComponent<DWChatItem>().content.rectTransform);
        var height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
        var width = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.width;

        if (width > 600)
        {
            width = 550;
            var content = one.GetComponent<DWChatItem>().content;
            content.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 0);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content.rectTransform);
            height = one.GetComponent<DWChatItem>().content.GetComponent<RectTransform>().rect.height;
            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(620, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);

        }
        else
        {
            one.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(width + 50, height + 50);
            one.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 50);
        }

        rectTransform.anchoredPosition = new Vector2(-(width + 100) / 2, 0);
    }

}
