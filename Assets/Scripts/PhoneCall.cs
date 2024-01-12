using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public void OnClickCamera() { }

    public void OnClickDrop()
    {
        Destroy(gameObject);
    }

    public void OnClickMute() { }


    public void OnGuideChoose()
    {
        UIManger.GetInstance().showChatBox(transform, "See you!", () =>
        {
            OnClickDrop();
        });
    }

    public void Start()
    {
        if (Utils.IsGuide())
        {
            UIManger.GetInstance().showChatBox(transform, "Hey James, have you heard about the new movie 'Gateway of Time?", () =>
               {
                   var list = new List<ChooseInfo> {
                        new("Hang Out",()=>{
                            Debug.Log("Choose 1");
                            OnGuideChoose();
                        }),
                        new("Audition",() => {
                            Debug.Log("Choose 2");
                            OnGuideChoose();
                        }) ,
                        new("Learn The Basics",() => {
                            Debug.Log("Choose 3");
                            OnGuideChoose();
                        }),
                   };
                   UIManger.GetInstance().showChooseBox(transform, list);
               });
        }

    }
}
