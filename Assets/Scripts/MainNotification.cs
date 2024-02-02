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

    public void InitPhoneNoti(System.Action func)
    {
        var phoneNode = Instantiate(phoneTip, notiContent.transform);
        phoneNode.GetComponent<MainSceneNotiBox>().InitPhoneCallNoti(func);

    }

    public void InitMessageTip(System.Action func)
    {
        var messageNode = Instantiate(messageTip, notiContent.transform);
        messageNode.GetComponent<MainSceneNotiBox>().InitMessageNoti(func);
    }

    public void ClearAllNotification()
    {

        foreach (Transform child in notiContent.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
