using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject answerBtn;
    public GameObject hangupBtn;
    public GameObject chatBox;

    public void onClickAnswer()
    {
        answerBtn.SetActive(false);
        chatBox.SetActive(true);
        StartCoroutine(Utils.SetTimeout(() =>
        {
            hangupBtn.SetActive(true);
        }, 1f));
    }

    public void onClickHangup()
    {
        //�Ҷϵ绰
        Destroy(gameObject);
    }


}
