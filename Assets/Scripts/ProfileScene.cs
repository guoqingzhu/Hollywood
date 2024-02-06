using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileScene : MonoBehaviour
{

    public TMP_Text nameLal;
    public TMP_Text ageLal;
    public TMP_Text genderLal;

    public TMP_Text romance;
    public TMP_Text sci;
    public TMP_Text action;
    public TMP_Text comdy;
    public TMP_Text mystery;

    public TMP_Text facial;
    public TMP_Text dialgue;
    public TMP_Text sing;
    public TMP_Text dancing;
    public TMP_Text body;


    public TMP_Text collaboration;
    public TMP_Text likability;


    public TMP_Text philsophy;
    public TMP_Text fortune;
    public TMP_Text aesthetic;


    public void OnClickBack()
    {
        Destroy(gameObject);
    }
}
