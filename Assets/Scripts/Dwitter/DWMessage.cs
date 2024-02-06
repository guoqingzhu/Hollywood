using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DWMessage : MonoBehaviour
{
    public GameObject headIcon;
    public GameObject nameText;
    public GameObject content;
    public GameObject date;

    public GameObject chatPage;
    public GameObject headImage;


    public void initNotification(string name, string contentt)
    {
        nameText.GetComponent<TMP_Text>().text = name;
        content.GetComponent<TMP_Text>().text = contentt;
        if (name == "Noah")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().noahHead;
        }
        else if (name == "Mia")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().miaHead;
        }
    }

    public void OnClickMessage()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ChatParent");
        var chat = Instantiate(chatPage, objectsWithTag[0].transform);
        chat.GetComponent<DWChat>().InitChatPage("Mia");

    }

}
