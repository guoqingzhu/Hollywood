using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour
{
    public TextMeshProUGUI context;
    public GameObject nextBtn;
    private bool hasSetFinish = false;
    private int curIndex = 1;


    public void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(onClickBox);
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

    public void InitChatBox(string msg)
    {
        context.text = msg;
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
                hasSetFinish = true;

            }
        }
    }

    private System.Collections.IEnumerator SetTimeout(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
