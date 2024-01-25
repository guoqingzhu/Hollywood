using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Regist : MonoBehaviour
{

    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_Dropdown genderSelect;

    public void OnClickFinish()
    {
        if (nameInput.text != "" && ageInput.text != "")
        {
            PlayerPrefs.SetString("playerName", nameInput.text);
            PlayerPrefs.SetInt("playerAge", int.Parse(ageInput.text));
            if (genderSelect.value == 0)
            {
                PlayerPrefs.SetString("playerGender", "male");
            }
            else
            {
                PlayerPrefs.SetString("playerGender", "female");
            }
            PlayerPrefs.SetInt("hasRegist", 1);
            gameObject.SetActive(false);
        }
    }


}
