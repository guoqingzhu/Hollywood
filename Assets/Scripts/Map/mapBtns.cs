using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapBtns : MonoBehaviour
{
    public void SetIsLock(bool isLock = true)
    {
        transform.GetChild(1).gameObject.SetActive(isLock);
        GetComponent<Button>().interactable = !isLock;
    }

}
