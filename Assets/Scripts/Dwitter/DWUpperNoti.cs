using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWUpperNoti : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text timeText;
    public TMP_Text contentText;

    public System.Action clickFunc;

    public void OnClick()
    {
        if (clickFunc != null) clickFunc();
        Destroy(gameObject);
    }

    public void  InitPhoneUpperNotifi(string title,string content,System.Action func) {
        titleText.text = title;
        contentText.text = content;
        timeText.text = DateTime.Now.ToShortTimeString();
        clickFunc = func;
    }

}
