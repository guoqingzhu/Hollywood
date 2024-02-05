using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public GameObject btns;


    private string dialogPath = "Data/Learning";
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

    public void OnClickLearn()
    {
        btns.SetActive(false);

        // learn....
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
                else {
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
