using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class movieItem : MonoBehaviour
{
    public GameObject filmPic;
    public TMP_Text filmName;
    public TMP_Text director;

    public GameObject filmTag;
    public GameObject tagsParent;

    public GameObject filmDetail;

    private FilmData curData = null;

    public void OnClickChoose()
    {
        var filDetail = Instantiate(filmDetail, transform.parent.parent.parent.parent.transform);
        filDetail.GetComponent<movieDetail>().Init(curData);
        Utils.GetInstance().eventName = filmName.text;

        PatchUserFilmReq data = new PatchUserFilmReq();
        data.device_id = Utils.playerName;
        data.key = curData.key;
        data.actors = curData.actors;
        string postData = JsonUtility.ToJson(data);
        string uri = NetManger.devpath + NetManger.patchFilm;
        var loading = UIManger.GetInstance().showLoading(transform);
        StartCoroutine(NetManger.GetInstance().PatchRequest(uri, postData, (resonse) =>
        {
            Debug.Log(resonse);
            Destroy(loading);
        }, (error) => { }));

    }

    public void Init(FilmData data)
    {
        curData = data;
        filmName.text = data.name;
        var cast = "";
        for (int i = 0; i < data.labels.Length; i++)
        {
            var tag = Instantiate(filmTag, tagsParent.transform);
            tag.GetComponentInChildren<TMP_Text>().text = data.labels[i];
            cast = data.labels[i] + "  ";
        }

        PlayerPrefs.SetString("filmCast", cast);

        for (int i = 0; i < data.actors.Length; i++)
        {
            if (data.actors[i].identity == "director")
            {
                director.text = data.actors[i].name;
                PlayerPrefs.SetString("director", data.actors[i].name);
            }
        }

    }

}
