using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// һ��ѡ���е�һ��
/// </summary>
public class SingleChooseBtn : MonoBehaviour
{

    public TextMeshProUGUI context;

    public void InitBtn(string msg)
    {
        context.text = msg;
    }

    public void OnClick()
    {

    }

}
