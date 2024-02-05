using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Utils : MonoBehaviour
{

    private static Utils _instance;


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



    // map lock
    public bool isStudioLock = true;
    public bool isLibraryLock = true;
    public bool isCafeLock = true;


}
