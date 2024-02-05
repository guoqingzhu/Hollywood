using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public GameObject btns;

    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void OnClickLearn()
    {
        btns.SetActive(false);

        // learn....


        UIManger.GetInstance().ShowUpperNotifi(GameObject.Find("Canvas").transform, "You recive a message", "Noah and " + Utils.playerName + " having a secret meeting", () =>
        {
            //返回主界面
            Destroy(transform.parent.gameObject);
            GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() =>
            {
                UIManger.GetInstance().ShowShootingScene(GameObject.Find("Canvas").transform);
            }, "Go on shooting");
        });
    }
}
