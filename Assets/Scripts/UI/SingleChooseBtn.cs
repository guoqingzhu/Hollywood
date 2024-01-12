using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseInfo
{
    public string chooseName;
    public delegate void Func();
    public Func func;

    public ChooseInfo(string name, Func cb)
    {
        chooseName = name;
        func = cb;
    }

}

/// <summary>
/// һ��ѡ���е�һ��
/// </summary>
public class SingleChooseBtn : MonoBehaviour
{

    public TextMeshProUGUI context;
    private ChooseInfo.Func func;

    public void InitBtn(ChooseInfo info)
    {
        context.text = info.chooseName;
        func = info.func;
    }

    public void OnClick()
    {
        func();
        // ѡ���ɾ������ѡ��
        Destroy(transform.parent.gameObject);
    }

}
