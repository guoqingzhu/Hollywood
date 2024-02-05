using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    public GameObject btns;

    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void OnClickWork()
    {
        btns.SetActive(false);

        // work....


        GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() =>
        {
            Utils.GetInstance().promotionLock = false;
            Destroy(GameObject.Find("mapScene(Clone)"));
            UIManger.GetInstance().ShowPromotionScene(GameObject.Find("Canvas").transform);
        }, "Your movie is promoting");
    }

}
