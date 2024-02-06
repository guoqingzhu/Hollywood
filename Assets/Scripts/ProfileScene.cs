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

    public void Start()
    {
        // 获取列表
        var loading = UIManger.GetInstance().showLoading(transform);
        var data = new GetUserInfoReq();
        data.device_id = Utils.playerName;
        string postData = JsonUtility.ToJson(data);
        string uri = NetManger.devpath + NetManger.getUserInfo + "?device_id=" + Utils.playerName;
        StartCoroutine(NetManger.GetInstance().GetRequest(uri, (resonse) =>
        {
            Destroy(loading);
            GetUserInfoType result = JsonUtility.FromJson<GetUserInfoType>(resonse);
            nameLal.text = result.data.nickname;
            ageLal.text = result.data.age.ToString();
            genderLal.text = result.data.gender;

            romance.text = result.data.attribute.values.romance_writing.ToString();
            sci.text = result.data.attribute.values.sciFi_writing.ToString();
            action.text = result.data.attribute.values.action_writing.ToString();
            comdy.text = result.data.attribute.values.comedy_writing.ToString();
            mystery.text = result.data.attribute.values.mystery_writing.ToString();

            facial.text = result.data.attribute.values.facial_expression.ToString();
            dialgue.text = result.data.attribute.values.dialogue.ToString();
            sing.text = result.data.attribute.values.singing.ToString();
            dancing.text = result.data.attribute.values.dancing.ToString();
            body.text = result.data.attribute.values.body_expression.ToString();

            collaboration.text = result.data.attribute.values.collaboration.ToString();
            likability.text = result.data.attribute.values.likability.ToString();

            philsophy.text = result.data.attribute.values.philosophy.ToString();
            fortune.text = result.data.attribute.values.fortune_telling.ToString();
            aesthetic.text = result.data.attribute.values.aesthetic.ToString();

        }, (error) => { }));
    }

    public void OnClickBack()
    {
        Destroy(gameObject);
    }
}
