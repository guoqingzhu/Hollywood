using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contact : MonoBehaviour
{
    public void OnClickBack()
    {
        SceneManager.LoadScene(0);
    }
}