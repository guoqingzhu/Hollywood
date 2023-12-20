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
    public Slider slider;

    public void Update()
    {
        player.GetComponent<SkeletonGraphic>().timeScale = slider.value;
    }

    public void onClickDwitter()
    {
        SceneManager.LoadScene(1);
    }

    public void onClickAudition()
    {
        SceneManager.LoadScene(2);
    }

}
