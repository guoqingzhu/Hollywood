using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWMessage : MonoBehaviour
{
    public GameObject headIcon;
    public GameObject nameText;
    public GameObject content;
    public GameObject date;

    public GameObject chatPage;

    public void initNotification(SingleMessageTip data)
    {

    }

    public void OnClickMessage()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ChatParent");
        var chat = Instantiate(chatPage, objectsWithTag[0].transform);
    }

}
