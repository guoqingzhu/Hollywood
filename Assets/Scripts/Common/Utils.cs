using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static System.Collections.IEnumerator SetTimeout(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }


    public static bool IsGuide()
    {
        return true;
    }

}
