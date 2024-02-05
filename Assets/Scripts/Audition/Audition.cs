using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audition : MonoBehaviour
{
    public GameObject mainNode;
    public GameObject typeNode;
    public GameObject onSiteDes;
    public GameObject btns;

    public GameObject dialogBg;
    public GameObject filmListItem;
    public GameObject itemParent;

    public FilmListType filmList;

    private string dialogPath = "Data/skipDialogs";
    private int curDialigIndex = 1;
    private List<string> dialogs;


    public void Start()
    {
        // 获取列表
        var loading = UIManger.GetInstance().showLoading(transform);
        var data = new GetFilmListReq();
        data.actor_num = 13;
        string postData = JsonUtility.ToJson(data);
        string uri = NetManger.devpath + NetManger.getFilmList + "?actor_num=13";
        StartCoroutine(NetManger.GetInstance().GetRequest(uri, (resonse) =>
        {
            Destroy(loading);
            filmList = JsonUtility.FromJson<FilmListType>(resonse);
            var list = filmList.data.list;

            for (int i = 0; i < list.Length; i++)
            {
                var item = Instantiate(filmListItem, itemParent.transform);
                item.GetComponent<movieItem>().Init(list[i]);
            }

        }, (error) => { }));


        EventManger.GetInstance().AddEventListener("ShowAuditionType", (EventData data) =>
        {
            mainNode.SetActive(false);
            typeNode.SetActive(true);
            //
            Debug.Log("add dialogs");
            ShowGuide();
        }, null);

        dialogs = readCSV.readFile(dialogPath);

    }

    public void ShowGuide()
    {
        dialogBg.SetActive(true);
        var name = dialogs[curDialigIndex].Split(",")[0];
        var dialog = dialogs[curDialigIndex].Split(",")[1];
        dialog = dialog.Replace("，", ",");
        UIManger.GetInstance().showActChatBox(transform, name, dialog, () =>
        {
            if (curDialigIndex < dialogs.Count - 1)
            {
                curDialigIndex += 1;
                ShowGuide();
            }
            else
            {
                dialogBg.SetActive(false);
            }
        });

    }


    public void OnClickMainBack()
    {
        // 返回主界面后显示一条通知
        var guideNode = transform.parent.parent.Find("Guide");
        guideNode.GetComponent<Guide>().ShowMesageShootingNotifi();
        Utils.GetInstance().shootingLock = false;
        Destroy(transform.parent.gameObject);
    }

    public void OnClickRemoteType() { }

    public void OnClickOnSiteType() { }


    public void OnClickSkip()
    {
        btns.SetActive(false);
        onSiteDes.SetActive(true);
    }
}
