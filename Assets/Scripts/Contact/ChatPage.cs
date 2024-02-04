using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatPage : MonoBehaviour
{
    public GameObject optionsNode;
    public GameObject contant;
    public GameObject chatItem;

    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void initOptions(string[] options)
    {
        for (int i = 0; i < 3; i++)
        {
            optionsNode.transform.GetChild(i).GetComponentInChildren<TMP_Text>().text = options[i];
        }
    }

    public void onClickOptionA()
    {
        Debug.Log("A");
    }

    public void onClickOptionB()
    {
        Debug.Log("B");
    }

    public void onClickOptionC()
    {
        Debug.Log("C");
    }


}
