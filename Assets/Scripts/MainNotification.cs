using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主界面的消息通知
/// </summary>
public class MainNotification : MonoBehaviour
{
    public GameObject notiContent;
    public GameObject phoneTip;
    public GameObject messageTip;

    public void InitPhoneNoti()
    {
        Instantiate(phoneTip, notiContent.transform);
    }

    public void InitMessageTip()
    {
        Instantiate(messageTip, notiContent.transform);
    }
}