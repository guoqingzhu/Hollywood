using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBox : MonoBehaviour
{
    public Transform content;
    public GameObject SingleChooseBoxPrefab;

    public void InitChooseBox(ArrayList items)
    {

        for (int i = 0; i < items.Count; i++)
        {
            var btn = Instantiate(SingleChooseBoxPrefab, content);
            btn.GetComponent<SingleChooseBtn>().InitBtn(items[i].ToString());
        }
    }
}
