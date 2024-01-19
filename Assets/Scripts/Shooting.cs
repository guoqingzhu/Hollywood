using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public GameObject ShootingPage;
    public GameObject FinalPage;
    public TMP_Text themeName;

    private StartGameType gameData;
    private int curIndex = 0;
    private string[] allDialogs;

    private string optionA = "";
    private string optionB = "";
    private string optionC = "";
    private string optionD = "";

    public void Start()
    {
        var loading = UIManger.GetInstance().showLoading(transform);
        string postData = "{\"device_id\": \"xxxx0001\", \"event_id\": \"TwoActorsInteraction\"}";
        string uri = NetManger.devpath + NetManger.startGame;
        StartCoroutine(NetManger.GetInstance().PostRequest(uri, postData, (resonse) =>
        {
            Destroy(loading);
            gameData = JsonUtility.FromJson<StartGameType>(resonse);
            string theme = gameData.data.event_theme;
            allDialogs = gameData.data.gpt_options.dialogue;
            themeName.text = theme;
            optionA = gameData.data.gpt_options.a;
            optionB = gameData.data.gpt_options.b;
            optionC = gameData.data.gpt_options.c;
            optionD = gameData.data.gpt_options.d;
        }, (error) => { }));
    }

    public void OnClickAct()
    {
        ShootingPage.SetActive(true);
        PlayGame();
    }

    public void OnClickHone()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickNextScene() { }

    /// <summary>
    /// 显示结果，但是需要提前将前置条件发给后端
    /// </summary>
    /// <param name="info"></param>
    Task ShowFinal(string info)
    {
        FinalPage.SetActive(true);
        return null;
    }

    void showOneDialog(int index)
    {
        curIndex = index;
        var curDialog = allDialogs[curIndex];
        var curName = curDialog.Split(':')[0];
        var dialog = curDialog.Split(':')[1];
        UIManger.GetInstance().showActChatBox(transform, curName, dialog, () =>
        {
            if (curIndex < allDialogs.Length - 1)
            {
                showOneDialog(curIndex += 1);
            }
            else
            {
                ShowOptions();
            }
        });
    }

    void ShowOptions()
    {
        var list = new List<ChooseInfo> {
                        new(optionA, ()=>{
                            ShowFinal(optionA);
                        }),
                        new(optionB,() => {
                           ShowFinal(optionB);
                        }) ,
                        new(optionC,() => {
                            ShowFinal(optionC);
                        }),
                         new(optionD,() => {
                            ShowFinal(optionD);
                        }),
                   };
        UIManger.GetInstance().showChooseBox(transform, list);
    }

    void PlayGame()
    {
        showOneDialog(curIndex);
    }
}
