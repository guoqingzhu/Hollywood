using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Utils : MonoBehaviour
{

    private static Utils _instance;

    public static string playerName = PlayerPrefs.GetString("playerName");

    public static Utils GetInstance()
    {
        return _instance ?? (_instance = new Utils());
    }


    /// <summary>
    /// 是否接听教程电话
    /// </summary>
    public bool hasGetGuideCall = false;

    public bool hasShowMapGuide = false;


    public static System.Collections.IEnumerator SetTimeout(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }


    public static bool IsGuide()
    {
        return true;
    }

    // mainScene lock
    public bool mapLock = false;
    public bool contactLock = false;
    public bool dwLock = false;
    public bool promotionLock = false;
    public bool shootingLock = false;

    // map lock
    public bool isStudioLock = false;
    public bool isLibraryLock = false;
    public bool isCafeLock = false;

    // 记录拍摄轮次，第二轮结尾提示进入dw
    public int shootingIndex = 0;
}
