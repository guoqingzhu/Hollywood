using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ShootingPage;
    public GameObject FinalPage;
    public TMP_Text themeName;

    public TMP_Text reaction_text;
    public TMP_Text event_progress_text;
    public TMP_Text roundNumText;

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
        var data = new StartGameReq();
        data.device_id = Utils.playerName;
        data.event_id = "TwoActorsInteraction";
        string postData = JsonUtility.ToJson(data);
        string uri = NetManger.devpath + NetManger.startGame;
        StartCoroutine(NetManger.GetInstance().PostRequest(uri, postData, (resonse) =>
        {
            Debug.Log(resonse);
            Destroy(loading);
            gameData = JsonUtility.FromJson<StartGameType>(resonse);
            string theme = gameData.data.event_theme;
            allDialogs = gameData.data.gpt_options.dialogue;
            themeName.text = theme;
            roundNumText.text = "The " + gameData.data.round_number + "rd" + " day of shooting";
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
        Destroy(gameObject);
    }

    public void OnClickNextScene()
    {
        Destroy(gameObject);
        UIManger.GetInstance().ShowShootingScene(transform.parent);
    }

    /// <summary>
    /// 显示结果
    /// </summary>
    /// <param name="info"></param>
    void ShowFinal(string info)
    {
        var loading = UIManger.GetInstance().showLoading(transform);
        var data = new GetResultReq();
        data.device_id = "xxxx0001";
        data.option_id = info;
        string postData = JsonUtility.ToJson(data);
        string uri = NetManger.devpath + NetManger.getResult;
        StartCoroutine(NetManger.GetInstance().PostRequest(uri, postData, (response) =>
        {
            Destroy(loading);
            Utils.GetInstance().shootingIndex += 1;
            FinalPage.SetActive(true);
            GetResultType result = JsonUtility.FromJson<GetResultType>(response);
            reaction_text.text = result.data.gpt_outcome.reaction;
            event_progress_text.text = result.data.gpt_outcome.event_progress;
            //
            if (Utils.GetInstance().shootingIndex == 2)
            {
                GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() =>
                {
                    Utils.GetInstance().dwLock = false;
                    Destroy(gameObject);
                    var node = UIManger.GetInstance().ShowDwitterScene(GameObject.Find("Canvas").transform);
                    node.GetComponentInChildren<DwitterScene>().showGuideUpper();
                });
            }

            // mia探班
            if (Utils.GetInstance().shootingIndex == 3)
            {
                //TODO
                //Destroy(gameObject);
                UIManger.GetInstance().ShowUpperNotifi(GameObject.Find("Canvas").transform, "You revice a message", "Mia send you a message", () =>
                {
                    Destroy(gameObject);
                    var node = UIManger.GetInstance().ShowDwitterScene(GameObject.Find("Canvas").transform);
                    node.GetComponentInChildren<DwitterScene>().getMessage("Mia", "This is my number");
                });
            }

            // noah 探班
            if (Utils.GetInstance().shootingIndex == 4)
            {
                UIManger.GetInstance().ShowUpperNotifi(GameObject.Find("Canvas").transform, "Noah send you a message", "You should make some money", () =>
                {
                    Destroy(gameObject);
                    Utils.GetInstance().noahMoney = true;
                    var node = UIManger.GetInstance().ShowcontactScene(GameObject.Find("Canvas").transform);
                });
            }

        }, (error) =>
        {
            Debug.Log(error);
        }));

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
                            ShowFinal("player_capture_select_option_goodness");
                        }),
                        new(optionB,() => {
                           ShowFinal("player_capture_select_option_evil");
                        }) ,
                        new(optionC,() => {
                            ShowFinal("player_capture_select_option_nonintervene");
                        }),
                         new(optionD,() => {
                            ShowFinal("player_capture_select_option_prank");
                        }),
                   };
        UIManger.GetInstance().showChooseBox(transform, list);
    }

    void PlayGame()
    {
        showOneDialog(curIndex);
    }
}
