using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public GameObject ShootingPage;

    public void Start()
    {
        string postData = "{\"device_id\": \"xxxx0001\", \"event_id\": \"TwoActorsInteraction\"}";
        string uri = NetManger.devpath + NetManger.startGame;
        StartCoroutine(NetManger.GetInstance().PostRequest(uri, postData, (resonse) => { }, (error) => { }));
        PlayGame();
    }

    public void OnClickAct()
    {
        ShootingPage.SetActive(true);
    }

    /// <summary>
    /// 显示结果，但是需要提前将前置条件发给后端
    /// </summary>
    /// <param name="info"></param>
    public Task ShowFinal(string info)
    {
        //
        return null;
    }

    public void PlayGame()
    {
        //UIManger.GetInstance().showActChatBox(transform, "Noah","Hey James, have you heard about the new movie 'Gateway of Time'?", () =>
        //{
        //    UIManger.GetInstance().showActChatBox(transform, "test","Yeah, I heard it's about some guy traveling between a modern city and a fantasy kingdom.", () =>
        //    {
        //        var list = new List<ChooseInfo> {
        //                new("Stays out of the argument between Mary and Gloria", ()=>{
        //                    Debug.Log("Choose 1");
        //                    SceneManager.LoadScene(0);
        //                }),
        //                new("Stays out of the argument between Mary and Gloria",() => {
        //                    Debug.Log("Choose 2");
        //                    SceneManager.LoadScene(0);
        //                }) ,
        //                new("Stays out of the argument between Mary and Gloria",() => {
        //                    Debug.Log("Choose 3");
        //                    SceneManager.LoadScene(0);
        //                }),
        //           };
        //        UIManger.GetInstance().showChooseBox(transform, list);
        //    });
        //});
    }
}
