using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Map : MonoBehaviour
{
    public void onClickBack() {
        SceneManager.LoadScene(0);
    }
}
