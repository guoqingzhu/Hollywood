using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWChatItem : MonoBehaviour
{
    public TMP_Text content;

    /// <summary>
    /// 入参之后要改成 SingleChatContent 用来判断是谁发的消息
    /// </summary>
    /// <param name="data"></param>
    public void initContent(string data)
    {
        content.text = data;
    }
}
