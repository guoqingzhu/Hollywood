using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneMessage : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text timeText;
    public TMP_Text contextText;
    public GameObject chatPage;


    private string chatName;

    public void InitMessage(string name, string context)
    {
        chatName = name;
        nameText.text = name;
        contextText.text = context;
        timeText.text = DateTime.Now.ToShortTimeString();
    }

    public void OnClick()
    {
        var chatNode = Instantiate(chatPage, GameObject.Find("contactScene(Clone)").transform);
        if (chatName == "Noah")
        {
            chatNode.GetComponent<ChatPage>().PlayOne();
        }
        else if (chatName == "Mia")
        {
            chatNode.GetComponent<ChatPage>().ChatWithMia();
        }
    }

}
