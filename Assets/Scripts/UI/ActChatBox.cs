using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActChatBox : MonoBehaviour
{
    public TextMeshProUGUI actname; // 讲话人名字
    public Image actorNode;  // 讲话人照片
    public TextMeshProUGUI context; // 讲话内容
    public GameObject nextBtn;
    public GameObject talkbox;

    private bool hasSetFinish = false;
    private int curIndex = 1;

    public delegate void CallBack();

    private CallBack callBack = null;

    public void Start()
    {
        talkbox.GetComponent<Button>().onClick.AddListener(onClickBox);
        //
        StartCoroutine(
       SetTimeout(() =>
       {
           int pages = context.textInfo.pageCount;
           if (curIndex < pages)
           {
               nextBtn.SetActive(true);
           }
       }, 0.01f));
    }

    public void InitChatBox(string name, Texture2D actor, string msg, CallBack cb = null)
    {
        //actorNode.GetComponent<Image>().material.mainTexture = actor;
        //actorNode.GetComponent<Image>().sprite = Sprite.Create(actor, new Rect(0, 0, actor.width, actor.height), new Vector2(0.5f, 0.5f));
        actname.text = name;
        context.text = msg;
        if (cb != null) callBack = cb;
        StartCoroutine(
       SetTimeout(() =>
       {
           int pages = context.textInfo.pageCount;
           if (curIndex < pages)
           {
               nextBtn.SetActive(true);
           }
       }, 0.01f));
    }

    public void onClickBox()
    {
        int pages = context.textInfo.pageCount;
        if (context.pageToDisplay < pages)
        {
            context.pageToDisplay += 1;
            if (context.pageToDisplay == pages)
            {
                nextBtn.SetActive(false);
            }
        }
        else
        {
            if (!hasSetFinish)
            {
                if (callBack != null) callBack();
                hasSetFinish = true;
                // 聊完后删除聊天框
                Destroy(gameObject);
            }
        }
    }

    private System.Collections.IEnumerator SetTimeout(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}


