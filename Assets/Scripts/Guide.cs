using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public MainNotification mainNotification;
    public GameObject phoneCallPage;

    public void Start()
    {
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


