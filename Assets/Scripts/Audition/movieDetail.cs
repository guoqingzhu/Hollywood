using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movieDetail : MonoBehaviour
{
    public void OnClickChoose()
    {
        EventManger.GetInstance().DispachEvent("ShowAuditionType");
        Destroy(gameObject);
    }
}
