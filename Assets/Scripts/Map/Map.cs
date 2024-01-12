using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Map : MonoBehaviour
{
    public void onClickBack()
    {
        SceneManager.LoadScene(0);
    }

    public void onClickCafe() { }

    public void onClickStudio()
    {
        SceneManager.LoadScene(5);
    }

    public void onClickCinema() { }

    public void onClickLibrary()
    {
        SceneManager.LoadScene(4);

    }

    public void onClickCBD() { }


    public void Start()
    {
        if (Utils.IsGuide())
        {
            UIManger.GetInstance().showChatBox(transform, "Let's go into the studio");
        }
    }

}
