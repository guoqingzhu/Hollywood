using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Contact : MonoBehaviour
{


    public TMP_Text title;

    public GameObject oneFriend;
    public GameObject oneMessage;

    public GameObject contactConent;
    public GameObject messageContent;

    public GameObject contactBtn;
    public GameObject messageBtn;

    public GameObject contactNode;
    public GameObject messageNode;


    private string contactPath = "Data/contact";
    private string dialogPath = "Data/mia";

    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void OnClickContact()
    {
        contactBtn.transform.GetChild(0).gameObject.SetActive(false);
        contactBtn.transform.GetChild(1).gameObject.SetActive(true);
        messageBtn.transform.GetChild(0).gameObject.SetActive(true);
        messageBtn.transform.GetChild(1).gameObject.SetActive(false);
        title.text = "Contact";
        contactNode.SetActive(true);
        messageNode.SetActive(false);
    }

    public void OnClickMessage()
    {
        messageBtn.transform.GetChild(0).gameObject.SetActive(false);
        messageBtn.transform.GetChild(1).gameObject.SetActive(true);
        contactBtn.transform.GetChild(0).gameObject.SetActive(true);
        contactBtn.transform.GetChild(1).gameObject.SetActive(false);
        title.text = "Message";
        contactNode.SetActive(false);
        messageNode.SetActive(true);
    }


    public void Start()
    {
        //load from csv
        OnClickContact();
        List<string> data = readCSV.readFile(contactPath);
        for (int i = 1; i < data.Count; i++)
        {
            var one = Instantiate(oneFriend, contactConent.transform);
            var friendName = data[i].Split(",")[0];
            var friendLevel = data[i].Split(",")[1];
            one.GetComponent<OneFriend>().InitFriend(friendName);
        }
        if (Utils.GetInstance().hasAddMia)
        {
            var one = Instantiate(oneFriend, contactConent.transform);
            one.GetComponent<OneFriend>().InitFriend("Mia");
        }
        //创建一个消息
        if (Utils.GetInstance().noahMoney)
        {
            var onem = Instantiate(oneMessage, messageContent.transform);
            onem.GetComponent<OneMessage>().InitMessage("Noah", "You should make some money");
        }
        else
        {

            List<string> dialogData = readCSV.readFile(dialogPath);
            var name = dialogData[1].Split(",")[0];
            var dialog = dialogData[1].Split(",")[1];
            dialog = dialog.Replace("，", ",");
            var onem = Instantiate(oneMessage, messageContent.transform);
            onem.GetComponent<OneMessage>().InitMessage(name, dialog);
        }

    }

}