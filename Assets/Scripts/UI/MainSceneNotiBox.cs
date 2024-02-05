using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 主界面的通知消息单个通知的脚本
/// </summary>
public class MainSceneNotiBox : MonoBehaviour
{

    public System.Action messageFunc = null;
    public System.Action phoneCallFunc = null;


    public void OnClickPhone()
    {
        if (phoneCallFunc != null) phoneCallFunc();
        Destroy(gameObject);
    }

    public void OnClickMessage()
    {
        if (messageFunc != null) messageFunc();
        Destroy(gameObject);
    }

    public void InitMessageNoti(System.Action func) {
        messageFunc = func;
    }

    public void InitPhoneCallNoti(System.Action func) {
        phoneCallFunc = func;
    }
}
