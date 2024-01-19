using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audition : MonoBehaviour
{
    public GameObject mainNode;
    public GameObject typeNode;
    public GameObject onSiteDes;
    public GameObject btns;

    public void Start()
    {
        EventManger.GetInstance().AddEventListener("ShowAuditionType", (EventData data) =>
        {
            mainNode.SetActive(false);
            typeNode.SetActive(true);
        }, null);
    }

    public void OnClickMainBack()
    {
        Destroy(gameObject);
    }

    public void OnClickRemoteType() { }

    public void OnClickOnSiteType() { }


    public void OnClickSkip()
    {
        btns.SetActive(false);
        onSiteDes.SetActive(true);
    }
}
