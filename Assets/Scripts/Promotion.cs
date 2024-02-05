using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Promotion : MonoBehaviour
{


    public GameObject mainNode;

    public GameObject director;
    public GameObject filmcast;
    public GameObject myRole;

    private string dialogPath = "Data/badMia";
    private int curDialigIndex = 1;
    private List<string> dialogs;



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
        data.event_type = "promotion";
        data.event_id = "MeetAndGreet";
        string postData = JsonUtility.ToJson(data);
        Debug.Log(postData);
        string uri = NetManger.devpath + NetManger.startGame;
        StartCoroutine(NetManger.GetInstance().PostRequest(uri, postData, (resonse) =>
        {
            Debug.Log(resonse);
            Destroy(loading);
            gameData = JsonUtility.FromJson<StartGameType>(resonse);
            string theme = gameData.data.event_theme;
            allDialogs = gameData.data.gpt_options.dialogue;
            optionA = gameData.data.gpt_options.a;
            optionB = gameData.data.gpt_options.b;
            optionC = gameData.data.gpt_options.c;
            optionD = gameData.data.gpt_options.d;

            director.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("director");
            filmcast.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("filmCast");
            myRole.GetComponent<TMP_Text>().text = "SUPPORTING";

        }, (error) => { }));
    }


    void PlayGame()
    {
        showOneDialog(curIndex);
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
                            playFinal();
                        }),
                        new(optionB,() => {
                            playFinal();

                        }) ,
                        new(optionC,() => {
                            playFinal();

                        }),
                         new(optionD,() => {
                            playFinal();

                        }),
                   };
        UIManger.GetInstance().showChooseBox(transform, list);
    }

    private void playFinal()
    {
        dialogs = readCSV.readFile(dialogPath);
        PlayMiaChat();
    }

    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void OnClickStart()
    {
        mainNode.SetActive(true);
        PlayGame();
    }

    public void PlayMiaChat()
    {
        mainNode.SetActive(true);
        var name = dialogs[curDialigIndex].Split(",")[0];
        var dialog = dialogs[curDialigIndex].Split(",")[1];
        dialog = dialog.Replace("��", ",");
        UIManger.GetInstance().showActChatBox(transform, name, dialog, () =>
        {
            if (curDialigIndex < dialogs.Count - 1)
            {
                curDialigIndex += 1;
                PlayMiaChat();
            }
            else
            {
                //dialogBg.SetActive(false);
            }
        });
    }
}
