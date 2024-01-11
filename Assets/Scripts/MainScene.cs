using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{

    public GameObject player;
    public GameObject guide;
    public GameObject mapBtn;

    public MainNotification notification;

    public void Start()
    {
        //var isNew = PlayerPrefs.GetString("isNew");
        //if (isNew == "")
        //{
        //    //show guide
        //    notification.InitPhoneNoti();
        //}
        //else
        //{
        //    //
        //}

        notification.InitPhoneNoti();
        //notification.InitMessageTip();
        //UIManger.GetInstance().showChatBox(transform,"asdasdasd");
        //var aa = new ArrayList();
        //aa.Add("aaa");
        //aa.Add("aaa");
        //aa.Add("aaa");
        //aa.Add("aaa");
        //UIManger.GetInstance().showChooseBox(transform, aa);
    }



    public void onClickDwitter()
    {
        SceneManager.LoadScene(1);
    }

    public void onClickContact()
    {
        SceneManager.LoadScene(6);
    }

    public void onClickAudition()
    {
        SceneManager.LoadScene(2);
    }

    public void onClickMap()
    {
        SceneManager.LoadScene(3);
    }

}
