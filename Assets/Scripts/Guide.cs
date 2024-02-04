using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public MainNotification mainNotification;
    public GameObject phoneCallPage;

    public GameObject finalNode;


    private string dialogPath = "Data/final";
    private int curDialigIndex = 1;
    private List<string> dialogs;

    public void PlayFinal()
    {
        finalNode.SetActive(true);
        var name = dialogs[curDialigIndex].Split(",")[0];
        var dialog = dialogs[curDialigIndex].Split(",")[1];
        dialog = dialog.Replace("£¬",",");
        UIManger.GetInstance().showActChatBox(finalNode.transform, name, dialog, () =>
        {
            if (curDialigIndex < dialogs.Count - 1)
            {
                curDialigIndex += 1;
                PlayFinal();
            }
        });

    }
    public void Start()
    {
        dialogs = readCSV.readFile(dialogPath);
        //PlayFinal();
        if (Utils.GetInstance().hasGetGuideCall == false)
        {
            mainNotification.InitPhoneNoti(() => { 
              Instantiate(phoneCallPage, GameObject.FindWithTag("MainPage").transform);
            });
        }
    }

    public void ShowGuidePhoneCall()
    {
        mainNotification.InitPhoneNoti(() => {
            Instantiate(phoneCallPage, GameObject.FindWithTag("MainPage").transform);
        });
    }

    public void ShowMesageNotifi()
    {
        mainNotification.InitMessageTip(() => {
            UIManger.GetInstance().ShowMapScene(transform.parent);
        });
    }


    public void ShowMesageShootingNotifi()
    {
        mainNotification.InitMessageTip(() => {
            UIManger.GetInstance().ShowShootingScene(transform.parent);
        });
    }

}


