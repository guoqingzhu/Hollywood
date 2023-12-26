using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DWNotification : MonoBehaviour
{
    public GameObject headIcon;
    public GameObject nameText;
    public GameObject content;
    public GameObject date;

    public void initNotification(SingleNotification data)
    {
        date.GetComponent<TMP_Text>().text = getCurDate();
    }

    private string getCurDate()
    {
        int month = DateTime.Now.Month;
        int day = DateTime.Now.Day;
        string date = "";

        switch (month)
        {
            case 1: date = "Jan"; break;
            case 2: date = "Feb"; break;
            case 3: date = "Mar"; break;
            case 4: date = "Apr"; break;
            case 5: date = "May"; break;
            case 6: date = "Jun"; break;
            case 7: date = "Jul"; break;
            case 8: date = "Aug"; break;
            case 9: date = "Sep"; break;
            case 10: date = "Oct"; break;
            case 11: date = "Nov"; break;
            case 12: date = "Dec"; break;
        }

        return date + "." + day;
    }

}
