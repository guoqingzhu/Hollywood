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

    public void initNotification(string name, string contentt)
    {
        nameText.GetComponent<TMP_Text>().text = name;
        content.GetComponent<TMP_Text>().text = contentt;
    }

    public void OnClickMessage()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ChatParent");
        var chat = Instantiate(chatPage, objectsWithTag[0].transform);
    }

}
