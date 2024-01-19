using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Studio : MonoBehaviour
{
    public void OnClickBack()
    {
        Destroy(gameObject);
    }
    public void Start()
    {
        if (Utils.IsGuide())
        {
            var list = new List<ChooseInfo> {
                new("Audition",() => {
                 Destroy(gameObject);
                    UIManger.GetInstance().ShowAuditionScene(transform.parent);
                }
                )};

            UIManger.GetInstance().showChooseBox(transform, list);
        }
    }
}
