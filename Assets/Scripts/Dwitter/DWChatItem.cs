using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWChatItem : MonoBehaviour
{
    public TMP_Text content;

    /// <summary>
    /// ���֮��Ҫ�ĳ� SingleChatContent �����ж���˭������Ϣ
    /// </summary>
    /// <param name="data"></param>
    public void initContent(string data)
    {
        content.text = data;
    }
}
