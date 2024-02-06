using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneMessage : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text timeText;
    public TMP_Text contextText;
    public GameObject chatPage;
    public GameObject headImage;


    private string chatName;

    public void InitMessage(string name, string context)
    {
        chatName = name;
        nameText.text = name;
        contextText.text = context;
        timeText.text = DateTime.Now.ToShortTimeString();
        if (name == "Noah")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().noahHead;
        }
        else if (name == "Mia")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().miaHead;
        }
    }

    public void OnClick()
    {
        var chatNode = Instantiate(chatPage, GameObject.Find("contactScene(Clone)").transform);
        if (chatName == "Noah")
        {
            chatNode.GetComponent<ChatPage>().InitChatPage("Noah");
            if (Utils.GetInstance().noahMoney)
            {
                string[] options = new string[1];
                options[0] = "OK";
                chatNode.GetComponent<ChatPage>().NoahMoney();
            }
            else
            {
                chatNode.GetComponent<ChatPage>().PlayOne();
            }
        }
        else if (chatName == "Mia")
        {
            chatNode.GetComponent<ChatPage>().InitChatPage("Mia");
            string[] options = new string[1];
            options[0] = "OK";
            chatNode.GetComponent<ChatPage>().ChatWithMia();
        }
    }

}
