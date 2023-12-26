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

    public void OnClickAudition()
    {
        SceneManager.LoadScene(2);
    }
}
