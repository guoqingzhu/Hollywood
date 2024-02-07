using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneFriend : MonoBehaviour
{
    public TMP_Text nameText;
    public GameObject chatPage;

    private string friendName;
    public GameObject headImage;


    public void OnClickPhone()
    {
        //Debug.Log("phone");
    }

    public void OnClickMessage()
    {
        //Debug.Log("Message");
        var chatNode = Instantiate(chatPage, GameObject.Find("contactScene(Clone)").transform);
        if (friendName == "Mia")
        {
            chatNode.GetComponent<ChatPage>().InitChatPage("Mia");
            chatNode.GetComponent<ChatPage>().ChatWithMia();
            string[] options = new string[1];
            options[0] = "OK";
            chatNode.GetComponent<ChatPage>().SetOptions(options);
        }
        else if (friendName == "Noah")
        {
            chatNode.GetComponent<ChatPage>().InitChatPage("Noah");
            if (Utils.GetInstance().noahMoney)
            {
                string[] options = new string[1];
                options[0] = "OK";
                chatNode.GetComponent<ChatPage>().SetOptions(options);
                chatNode.GetComponent<ChatPage>().NoahMoney();
            }
            else
            {
                chatNode.GetComponent<ChatPage>().PlayOne();
            }
        }
    }

    public void OnClickInvite()
    {
        //Debug.Log("Invite");
    }

    public void InitFriend(string name)
    {
        nameText.text = name;
        friendName = name;

        if (name == "Noah")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().noahHead;
        }
        else if (name == "Mia")
        {
            headImage.GetComponent<Image>().sprite = GameObject.Find("Canvas").GetComponent<MainScene>().miaHead;
        }

    }

}
