using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneFriend : MonoBehaviour
{
    public TMP_Text nameText;
    public GameObject chatPage;

    private string friendName;

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
            chatNode.GetComponent<ChatPage>().ChatWithMia();
            string[] options = new string[1];
            options[0] = "OK";
            chatNode.GetComponent<ChatPage>().SetOptions(options);
        }
        else if (friendName == "Noah")
        {
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
    }

    public void OnClickInvite()
    {
        //Debug.Log("Invite");
    }

    public void InitFriend(string name)
    {
        nameText.text = name;
        friendName = name;
    }

}
