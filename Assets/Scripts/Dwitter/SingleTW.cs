using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleTW : MonoBehaviour
{
    public GameObject thead;
    public GameObject tName;
    public GameObject tdate;
    public GameObject textbox;

    public GameObject comment;
    public GameObject share;
    public GameObject like;

    public void initTW(GetCommentData data)
    {
        //tName.GetComponent<TMP_Text>().text = data.name;

        //textbox.GetComponent<TMP_Text>().text = data.content;

        //comment.GetComponent<TMP_Text>().text = data.commentNum.ToString();
        //share.GetComponent<TMP_Text>().text = data.shareNum.ToString();
        //like.GetComponent<TMP_Text>().text = data.likeNum.ToString();

        tdate.GetComponent<TMP_Text>().text = getCurDate();
        textbox.GetComponent<TMP_Text>().text = data.gpt_news.post;

        //
        StartCoroutine(SetTimeout(() =>
        {
            var height = textbox.GetComponent<RectTransform>().rect.height;
            var targetHeight = height + 180;
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);
        }, 0.01f));
    }

    private string getCurDate()
    {
        int month = DateTime.Now.Month;
        int day = DateTime.Now.Day;
        string date = "";

        switch (month)
        {
            case 1: date = "Jan"; break;
            case 2: date = "Feb"; break;
            case 3: date = "Mar"; break;
            case 4: date = "Apr"; break;
            case 5: date = "May"; break;
            case 6: date = "Jun"; break;
            case 7: date = "Jul"; break;
            case 8: date = "Aug"; break;
            case 9: date = "Sep"; break;
            case 10: date = "Oct"; break;
            case 11: date = "Nov"; break;
            case 12: date = "Dec"; break;
        }

        return date + "." + day;
    }

    private System.Collections.IEnumerator WaitForNextFrame()
    {
        yield return null; // 等待下一帧

        // 在下一帧执行的代码
        Debug.Log("Next frame");
    }

    private System.Collections.IEnumerator SetTimeout(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
