
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

}
