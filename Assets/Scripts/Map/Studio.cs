using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Studio : MonoBehaviour
{
    public void OnClickBack()
    {
        SceneManager.LoadScene(3);
    }
    public void Start()
    {
        if (Utils.IsGuide())
        {
            var list = new List<ChooseInfo> {
                new("Audition",() => {
                 SceneManager.LoadScene(2);
                }
                )};

            UIManger.GetInstance().showChooseBox(transform, list);
        }
    }
}
