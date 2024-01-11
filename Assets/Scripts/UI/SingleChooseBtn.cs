using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 一组选项中的一个
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
