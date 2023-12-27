using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movieItem : MonoBehaviour
{
    public GameObject filmPic;
    public GameObject fileName;
    public GameObject director;

    public GameObject filmDetail;

    public void OnClickChoose()
    {
        Instantiate(filmDetail, transform.parent.parent.parent.parent.transform);
    }
}
