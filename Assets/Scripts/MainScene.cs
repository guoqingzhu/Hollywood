using Spine.Unity;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{

    public GameObject player;
    public GameObject guide;
    public GameObject mapBtn;

    public MainNotification notification;

    public void Start()
    {

    }

    public void OnClickNetTest()
    {
        string uri = NetManger.devpath + NetManger.getUserInfo + "?device_id=xxxx0001";
        Debug.Log(uri);
        StartCoroutine(NetManger.GetInstance().GetRequest(uri, (response) =>
        {
            Debug.Log("Request successful. Response: " + response);
            GetUserInfoType userInfo = JsonUtility.FromJson<GetUserInfoType>(response);
            Debug.Log("att:" + userInfo.data.attribute.values.fame);
        }, (error) =>
        {
            Debug.Log("Request failed. Error: " + error);
        }));
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

    public void onClickShooting()
    {
        UIManger.GetInstance().ShowShootingScene(transform);
    }

    public void onClickMap()
    {
        SceneManager.LoadScene(3);
    }


    public void ClickTest()
    {
        Debug.Log("zgq---test");
    }
}
