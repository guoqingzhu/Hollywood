
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

        //����ȷ���Ѿ��Ǽǹ���Ϣ
        var hasRegist = PlayerPrefs.GetInt("hasRegist");
        if (hasRegist == 1)
        {
            registNode.SetActive(false);
        }
    }

    public void onClickDwitter()
    {
        UIManger.GetInstance().ShowDwitterScene(transform);
    }

    public void onClickContact()
    {
        UIManger.GetInstance().ShowcontactScene(transform);
    }

    public void onClickAudition()
    {
        UIManger.GetInstance().ShowAuditionScene(transform);
    }

    public void onClickShooting()
    {
        UIManger.GetInstance().ShowShootingScene(transform);
    }

    public void onClickMap()
    {
        UIManger.GetInstance().ShowMapScene(transform);
    }


    /// <summary>
    /// ȫ��UI֪ͨ
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
