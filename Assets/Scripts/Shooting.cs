using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ShootingPage;

    public void Start()
    {

    }

    public void OnClickAct()
    {
        ShootingPage.SetActive(true);
    }
}
