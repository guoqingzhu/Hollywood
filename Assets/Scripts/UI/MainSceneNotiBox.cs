using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 主界面的通知消息单个通知的脚本
/// </summary>
public class MainSceneNotiBox : MonoBehaviour
{

    public GameObject phoneCallPage;

    public void OnClickPhone()
    {
        Destroy(gameObject);
        Instantiate(phoneCallPage, GameObject.FindWithTag("MainPage").transform);
    }

    public void OnClickMessage()
    {
        Destroy(gameObject);
    }
}
