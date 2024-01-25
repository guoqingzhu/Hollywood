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
        Debug.Log("onclick choose");
        var filDetail = Instantiate(filmDetail, transform.parent.parent.parent.parent.transform);
        filDetail.GetComponent<movieDetail>().Init(curData);
    }

    public void Init(FilmData data)
    {
        curData = data;
        filmName.text = data.name;
        for (int i = 0; i < data.labels.Length; i++)
        {
            var tag = Instantiate(filmTag, tagsParent.transform);
            tag.GetComponentInChildren<TMP_Text>().text = data.labels[i];
        }

        for (int i = 0; i < data.actors.Length; i++)
        {
            if (data.actors[i].identity == "director")
            {
                director.text = data.actors[i].name;
            }
        }

    }

}
