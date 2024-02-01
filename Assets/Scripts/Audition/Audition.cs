using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audition : MonoBehaviour
{
    public GameObject mainNode;
    public GameObject typeNode;
    public GameObject onSiteDes;
    public GameObject btns;

    public GameObject filmListItem;
    public GameObject itemParent;

    public FilmListType filmList;

    public void Start()
    {
        // ��ȡ�б�
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
        }, null);
    }

    public void OnClickMainBack()
    {
        // �������������ʾһ��֪ͨ
        var guideNode = transform.parent.parent.Find("Guide");
        guideNode.GetComponent<Guide>().ShowMesageShootingNotifi();
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
