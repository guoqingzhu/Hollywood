
using UnityEngine;

public class MainScene : MonoBehaviour
{

    public GameObject player;
    public GameObject guide;
    public GameObject mapBtn;
    public GameObject registNode;

    public MainNotification notification;


    private void Start()
    {

        //PlayerPrefs.DeleteAll();

        //用于确保已经登记过信息
        var hasRegist = PlayerPrefs.GetInt("hasRegist");
        if (hasRegist == 1)
        {
            registNode.SetActive(false);
        }
    }
  
    public void onClickMap()
    {
        UIManger.GetInstance().ShowMapScene(transform);
    }

    public void onClickContact()
    {
        UIManger.GetInstance().ShowcontactScene(transform);
    }

    public void onClickDwitter()
    {
        UIManger.GetInstance().ShowDwitterScene(transform);
    }

    public void onClickPromotion()
    {
        UIManger.GetInstance().ShowPromotionScene(transform);
    }

    public void onClickShooting()
    {
        UIManger.GetInstance().ShowShootingScene(transform);
    }



    /// <summary>
    /// 全局UI通知
    ///  GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() => { });
    /// </summary>
    /// <param name="func"></param>
    public void ShowPhoneCallNotifi(System.Action func)
    {
        notification.ClearAllNotification();
        notification.transform.SetSiblingIndex(999);
        notification.InitPhoneNoti(func);
    }

    /// <summary>
    ///  GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() => { });
    /// </summary>
    /// <param name="func"></param>
    public void ShowMessageNotifi(System.Action func)
    {
        notification.ClearAllNotification();
        notification.transform.SetSiblingIndex(999);
        notification.InitMessageTip(func);
    }

}
