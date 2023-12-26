using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Library : MonoBehaviour
{
    public void OnClickBack()
    {
        SceneManager.LoadScene(3);
    }
}
