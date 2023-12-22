using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DWFooter : MonoBehaviour
{
    public GameObject discoverBtn;
    public GameObject notificationBtn;
    public GameObject messageBtn;
    public GameObject profileBtn;

    private int curIndex = 0;

    public void Awake()
    {
        discoverBtn.GetComponent<Button>().onClick.AddListener(OnClickBtn);
        notificationBtn.GetComponent<Button>().onClick.AddListener(OnClickBtn);
        messageBtn.GetComponent<Button>().onClick.AddListener(OnClickBtn);
        profileBtn.GetComponent<Button>().onClick.AddListener(OnClickBtn);
        ChoosePage(0);
    }

    public void ResetAllBtn()
    {
        discoverBtn.transform.GetChild(0).gameObject.SetActive(true);
        notificationBtn.transform.GetChild(0).gameObject.SetActive(true);
        messageBtn.transform.GetChild(0).gameObject.SetActive(true);
        profileBtn.transform.GetChild(0).gameObject.SetActive(true);
        discoverBtn.transform.GetChild(1).gameObject.SetActive(false);
        notificationBtn.transform.GetChild(1).gameObject.SetActive(false);
        messageBtn.transform.GetChild(1).gameObject.SetActive(false);
        profileBtn.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void ChoosePage(int index)
    {
        curIndex = index;
        switch (index)
        {
            case 0:
                discoverBtn.transform.GetChild(0).gameObject.SetActive(false);
                discoverBtn.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 1:
                notificationBtn.transform.GetChild(0).gameObject.SetActive(false);
                notificationBtn.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                messageBtn.transform.GetChild(0).gameObject.SetActive(false);
                messageBtn.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                profileBtn.transform.GetChild(0).gameObject.SetActive(false);
                profileBtn.transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    public void OnClickBtn()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        ResetAllBtn();
        if (clickedButton != null)
        {
            switch (clickedButton.name)
            {
                case "discover":
                    ChoosePage(0);
                    break;
                case "notification":
                    ChoosePage(1);
                    break;
                case "message":
                    ChoosePage(2);
                    break;
                case "profile":
                    ChoosePage(3);
                    break;
            }
        }
    }

    public int getCurPageIndex()
    {
        return curIndex;
    }
}
