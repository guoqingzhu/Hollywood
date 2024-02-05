using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promotion : MonoBehaviour
{


    public GameObject mainNode;

    private string dialogPath = "Data/badMia";
    private int curDialigIndex = 1;
    private List<string> dialogs;



    private void Start()
    {
        dialogs = readCSV.readFile(dialogPath);

        PlayMiaChat();

    }

    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void OnClickStart() { }

    public void PlayMiaChat()
    {
        mainNode.SetActive(true);
        var name = dialogs[curDialigIndex].Split(",")[0];
        var dialog = dialogs[curDialigIndex].Split(",")[1];
        dialog = dialog.Replace("£¬", ",");
        UIManger.GetInstance().showActChatBox(transform, name, dialog, () =>
        {
            if (curDialigIndex < dialogs.Count - 1)
            {
                curDialigIndex += 1;
                PlayMiaChat();
            }
            else
            {
                //dialogBg.SetActive(false);
            }
        });
    }
}
