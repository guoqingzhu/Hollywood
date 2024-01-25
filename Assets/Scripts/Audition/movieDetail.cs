using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movieDetail : MonoBehaviour
{

    public TMP_Text director;
    public TMP_Text lead_actor;
    public TMP_Text tags;

    public TMP_Text title;
    public TMP_Text description;

    public void Init(FilmData data)
    {
        for (int i = 0; i < data.actors.Length; i++)
        {
            if (data.actors[i].identity == "director")
            {
                director.text = data.actors[i].name;
            }

            if (data.actors[i].identity == "leading")
            {
                lead_actor.text = data.actors[i].name;
            }
        }


        for (int i = 0; i < data.labels.Length; i++)
        {
            Debug.Log(data.labels[i]);
            tags.text += " " + data.labels[i];
        }

        title.text = data.name;
        description.text = data.synopsis;

    }

    public void OnClickChoose()
    {
        EventManger.GetInstance().DispachEvent("ShowAuditionType");
        Destroy(gameObject);
    }
}
