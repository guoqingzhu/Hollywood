using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{

    public MainNotification mainNotification;

    public void Start()
    {
        mainNotification.InitPhoneNoti();

        //UIManger.GetInstance().showChatBox(transform.parent, "HIHIHI", () =>
        //{
        //    Debug.Log("zzzfinish");
        //});

    }
}
