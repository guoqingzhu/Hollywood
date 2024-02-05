using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class Regist : MonoBehaviour
{

    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_Dropdown genderSelect;

    public void OnClickFinish()
    {
        if (nameInput.text != "" && ageInput.text != "")
        {
            var data = new AddUserReq();
            data.device_id = nameInput.text;
            data.nickname = nameInput.text;
            data.age = int.Parse(ageInput.text);
            PlayerPrefs.SetString("playerName", nameInput.text);
            PlayerPrefs.SetInt("playerAge", int.Parse(ageInput.text));
            if (genderSelect.value == 0)
            {
                PlayerPrefs.SetString("playerGender", "male");
                data.gender = "male";
            }
            else
            {
                PlayerPrefs.SetString("playerGender", "female");
                data.gender = "Female";
            }
            PlayerPrefs.SetInt("hasRegist", 1);

            string postData = JsonUtility.ToJson(data);
            string uri = NetManger.devpath + NetManger.addUser;
            var loading = UIManger.GetInstance().showLoading(transform);
            StartCoroutine(NetManger.GetInstance().PostRequest(uri, postData, (resonse) =>
            {
                Debug.Log(resonse);
                gameObject.SetActive(false);
                Destroy(loading);
            }, (error) => { }));
        }
    }


}
