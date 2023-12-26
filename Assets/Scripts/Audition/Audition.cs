using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audition : MonoBehaviour
{
    public void OnClickBack()
    {
        SceneManager.LoadScene(5);
    }
}
