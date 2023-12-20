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

    public void initTW(string data)
    {
        //tName.GetComponent<TMP_Text>().text = data.name;
        //tdate.GetComponent<TMP_Text>().text = data.date;

        //textbox.GetComponent<TMP_Text>().text = data.content;

        //comment.GetComponent<TMP_Text>().text = data.commentNum.ToString();
        //share.GetComponent<TMP_Text>().text = data.shareNum.ToString();
        //like.GetComponent<TMP_Text>().text = data.likeNum.ToString();

        textbox.GetComponent<TMP_Text>().text = data;

        //
        StartCoroutine(SetTimeout(() =>
        {
            var height = textbox.GetComponent<RectTransform>().rect.height;
            Debug.Log(height);
            var targetHeight = height + 180;
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);
        }, 0.01f));
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
