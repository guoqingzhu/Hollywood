using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    public void Start()
    {
        //GameObject.Find("Canvas").GetComponent<MainScene>().ShowMessageNotifi(() => { });
    }

}