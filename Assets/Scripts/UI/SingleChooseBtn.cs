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
/// 一组选项中的一个
/// </summary>
public class SingleChooseBtn : MonoBehaviour
{

    public TextMeshProUGUI context;
    private ChooseInfo.Func func;

    public GameObject attributeIcon;


    public void InitBtn(ChooseInfo info)
    {
        var msg = char.ToUpper(info.chooseName[0]) + info.chooseName.Substring(1);
        context.text = msg;
        func = info.func;
        if (info.attinfo != null)
        {
            // add icon
            attributeIcon.SetActive(true);
            context.GetComponent<RectTransform>().offsetMin = new Vector2(120, context.GetComponent<RectTransform>().offsetMin.y);

            string imageName = info.attinfo.key;
            if (info.attinfo.value < 4)
            {
                imageName += "_0";
            }
            else if (info.attinfo.value >= 4 || info.attinfo.value < 8)
            {
                imageName += "_1";

            }
            else
            {
                imageName += "_2";

            }
            Sprite myImage = Resources.Load<Sprite>("images/hollywood_attribute/" + imageName);
            attributeIcon.GetComponent<Image>().sprite = myImage;
        }
    }

    public void OnClick()
    {
        func();
        // 选完后删除所有选项
        Destroy(transform.parent.gameObject);
    }

}
