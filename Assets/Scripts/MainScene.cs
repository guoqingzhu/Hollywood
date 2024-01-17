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

    }

    public void OnClickNetTest()
    {
        // string postData = "{\"device_id\": \"xxxx0001\", \"event_id\": \"TwoActorsInteraction\"}";
        string postData = "{\"device_id\": \"xxxx0001\", \"option_id\": \"player_capture_select_option_goodness\"}";
        System.Action<string> onSuccess = (response) =>
        {
            Debug.Log("Request successful. Response: " + response);
            //StartGameType startGameType = JsonUtility.FromJson<StartGameType>(response);
            GetResultType startGameType = JsonUtility.FromJson<GetResultType>(response);
            Debug.Log(startGameType.data.gpt_outcome.Event_Progress);
            // 在这里处理成功响应的逻辑
        };

        // 定义请求失败时要执行的操作
        System.Action<string> onFailure = (error) =>
        {
            Debug.Log("Request failed. Error: " + error);
            // 在这里处理失败响应的逻辑
        };

        string uri = NetManger.devpath + NetManger.getResult;

        StartCoroutine(NetManger.GetInstance().PostRequest(uri, postData, onSuccess, onFailure));
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
        SceneManager.LoadScene(7);
    }

    public void onClickMap()
    {
        SceneManager.LoadScene(3);
    }

}
