using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject studioBtn;
    public GameObject libraryBtn;
    public GameObject cafeBtn;

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
        if (Utils.IsGuide() && !Utils.GetInstance().hasShowMapGuide)
        {
            Utils.GetInstance().hasShowMapGuide = true;
            UIManger.GetInstance().showChatBox(transform, "Noah", "Let's go into the studio");
        }

        studioBtn.GetComponent<mapBtns>().SetIsLock(Utils.GetInstance().isStudioLock);
        libraryBtn.GetComponent<mapBtns>().SetIsLock(Utils.GetInstance().isLibraryLock);
        cafeBtn.GetComponent<mapBtns>().SetIsLock(Utils.GetInstance().isCafeLock);

    }

}
