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
            Debug.Log("get...");
            mainNode.SetActive(false);
            typeNode.SetActive(true);
        }, null);
    }

    public void OnClickMainBack()
    {
        SceneManager.LoadScene(5);
    }

    public void OnClickChooseTypeBack()
    {
        mainNode.SetActive(true);
        typeNode.SetActive(false);
    }

    public void OnClickRemoteType() { }

    public void OnClickOnSiteType()
    {
        //onSiteDes.SetActive(true);
    }


    public void OnClickSkip()
    {
        btns.SetActive(false);
        onSiteDes.SetActive(true);
    }

    public void OnClickChooseAudition()
    {
        if (Utils.IsGuide())
        {
            SceneManager.LoadScene(0);
        }
    }
}
