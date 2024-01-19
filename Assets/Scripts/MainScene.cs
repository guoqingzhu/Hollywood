using Spine.Unity;
using UnityEditor.PackageManager;
using UnityEngine;

public class MainScene : MonoBehaviour
{

    public GameObject player;
    public GameObject guide;
    public GameObject mapBtn;

    public MainNotification notification;

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
