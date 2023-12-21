using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{

    public GameObject player;
    public GameObject guide;

    public GameObject mapBtn;

    public void Start()
    {
        var isNew = PlayerPrefs.GetString("isNew");
        Debug.Log(isNew);
        if (isNew == "")
        {
            Instantiate(guide, transform);
            PlayerPrefs.SetString("isNew", "false");
            mapBtn.SetActive(true);
        }
        else
        {
            mapBtn.SetActive(true);

        }
    }



    public void onClickDwitter()
    {
        SceneManager.LoadScene(1);
    }

    public void onClickAudition()
    {
        SceneManager.LoadScene(2);
    }

    public void onClickMap() {
        SceneManager.LoadScene(3);
    }

}
