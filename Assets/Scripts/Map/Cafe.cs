using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    public GameObject btns;


    private string dialogPath = "Data/working";
    private int curDialigIndex = 1;
    private List<string> dialogs;

    public void OnClickBack()
    {
        Destroy(gameObject);
    }


    private void Start()
    {
        dialogs = readCSV.readFile(dialogPath);
    }

    public void OnClickWork()
    {
        btns.SetActive(false);

        // work....

        PlayOne();

    }

    public void PlayOne()
    {
        var name = dialogs[curDialigIndex].Split(",")[0];
        var dialog = dialogs[curDialigIndex].Split(",")[1];

        UIManger.GetInstance().showActChatBox(transform, name, dialog, () =>
        {

            if (curDialigIndex + 1 < dialogs.Count)
            {
                if (name != "Player")
                {
                   
                    var shortStr = dialogs[curDialigIndex += 1].Split(",")[2];
                    var list = new List<ChooseInfo> {
                        new(shortStr,()=>{
                               PlayOne();
                        }),
                   };
                    UIManger.GetInstance().showChooseBox(transform, list);
                }
                else
                {
                    curDialigIndex += 1;
                    PlayOne();
                }
            }
            else
            {
                PlayFinal();
            }
        });



    }


    private void PlayFinal()
    {
        GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() =>
        {
            Utils.GetInstance().promotionLock = false;
            Destroy(GameObject.Find("mapScene(Clone)"));
            UIManger.GetInstance().ShowPromotionScene(GameObject.Find("Canvas").transform);
        }, "Your movie is promoting");
    }

}
