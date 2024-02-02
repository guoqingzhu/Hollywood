using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneMessage : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text timeText;
    public TMP_Text contextText;

    public void InitMessage(string name,string context) {
        nameText.text = name;
        contextText.text = context;
        timeText.text = DateTime.Now.ToShortTimeString();
    }

    public void OnClick() { }

}
