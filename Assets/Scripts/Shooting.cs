using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ShootingPage;

    public void Start()
    {
        if (Utils.IsGuide())
        {
            PlayGuide();
        }
    }

    public void OnClickAct()
    {
        ShootingPage.SetActive(true);
    }

    public void PlayGuide()
    {
        UIManger.GetInstance().showActChatBox(transform, "Noah", "Hey James, have you heard about the new movie 'Gateway of Time'?", () =>
        {
            UIManger.GetInstance().showActChatBox(transform, "James", "Yeah, I heard it's about some guy traveling between a modern city and a fantasy kingdom.", () =>
            {
                var list = new List<ChooseInfo> {
                        new("Stays out of the argument between Mary and Gloria",()=>{
                            Debug.Log("Choose 1");
                        }),
                        new("Stays out of the argument between Mary and Gloria",() => {
                            Debug.Log("Choose 2");
                        }) ,
                        new("Stays out of the argument between Mary and Gloria",() => {
                            Debug.Log("Choose 3");
                        }),
                   };
                UIManger.GetInstance().showChooseBox(transform, list);
            });
        });
    }
}
