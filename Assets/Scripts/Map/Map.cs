using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public void onClickBack()
    {
        Destroy(gameObject);
    }

    public void onClickCafe() { }

    public void onClickStudio()
    {
        UIManger.GetInstance().ShowStudioScene(transform);
    }

    public void onClickCinema() { }

    public void onClickLibrary()
    {
        UIManger.GetInstance().ShowLibiaryScene(transform);
    }

    public void onClickCBD() { }


    public void Start()
    {
        if (Utils.IsGuide())
        {
            UIManger.GetInstance().showChatBox(transform, "Noah", "Let's go into the studio");
        }
    }

}
