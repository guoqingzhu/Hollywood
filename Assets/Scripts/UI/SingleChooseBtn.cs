using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseInfo
{
    public string chooseName;
    public attInfo attinfo;
    public delegate void Func();
    public Func func;

    public ChooseInfo(string name, Func cb, attInfo att = null)
    {
        chooseName = name;
        func = cb;
        if (att != null) attinfo = att;
    }

}

/// <summary>
/// һ��ѡ���е�һ��
/// </summary>
public class SingleChooseBtn : MonoBehaviour
{

    public TextMeshProUGUI context;
    private ChooseInfo.Func func;

    public GameObject attributeIcon;


    public void InitBtn(ChooseInfo info)
    {
        context.text = info.chooseName;
        func = info.func;
        if (info.attinfo != null)
        {
            Debug.Log(info.attinfo.key + "  " + info.attinfo.value);
            // add icon
            attributeIcon.SetActive(true);
            context.GetComponent<RectTransform>().offsetMin = new Vector2(120, context.GetComponent<RectTransform>().offsetMin.y);

            Sprite myImage = Resources.Load<Sprite>("images/hollywood_attribute/test");
            attributeIcon.GetComponent<Image>().sprite = myImage;
        }
    }

    public void OnClick()
    {
        func();
        // ѡ���ɾ������ѡ��
        Destroy(transform.parent.gameObject);
    }

}
