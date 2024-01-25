using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public MainNotification mainNotification;

    public void Start()
    {
        if (Utils.GetInstance().hasGetGuideCall == false)
        {
            mainNotification.InitPhoneNoti();
        }
    }

    public void ShowGuidePhoneCall()
    {
        mainNotification.InitPhoneNoti();
    }
}
