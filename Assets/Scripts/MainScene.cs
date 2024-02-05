
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{

    public GameObject player;
    public GameObject guide;
    public GameObject mapBtn;
    public GameObject registNode;

    public MainNotification notification;

    public GameObject mapBtnNode;
    public GameObject contactBtnNode;
    public GameObject dwBtnNode;
    public GameObject promotionBtnNode;
    public GameObject shootingBtnNode;

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

    private void Update()
    {
        // set lock
        mapBtnNode.GetComponent<Button>().interactable = !Utils.GetInstance().mapLock;
        contactBtnNode.GetComponent<Button>().interactable = !Utils.GetInstance().contactLock;
        dwBtnNode.GetComponent<Button>().interactable = !Utils.GetInstance().dwLock;
        promotionBtnNode.GetComponent<Button>().interactable = !Utils.GetInstance().promotionLock;
        shootingBtnNode.GetComponent<Button>().interactable = !Utils.GetInstance().shootingLock;
    }

    public void onClickMap()
    {
        notification.ClearAllNotification();
        UIManger.GetInstance().ShowMapScene(transform);
    }

    public void onClickContact()
    {
        notification.ClearAllNotification();
        UIManger.GetInstance().ShowcontactScene(transform);
    }

    public void onClickDwitter()
    {
        notification.ClearAllNotification();
        UIManger.GetInstance().ShowDwitterScene(transform);
    }

    public void onClickPromotion()
    {
        notification.ClearAllNotification();
        UIManger.GetInstance().ShowPromotionScene(transform);
    }

    public void onClickShooting()
    {
        notification.ClearAllNotification();
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
