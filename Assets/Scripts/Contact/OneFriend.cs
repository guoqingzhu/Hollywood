using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneFriend : MonoBehaviour
{
    public TMP_Text nameText;
    public GameObject chatPage;


    public void OnClickPhone() {
        //Debug.Log("phone");
    }

    public void OnClickMessage() {
        //Debug.Log("Message");
        var chatNode = Instantiate(chatPage, GameObject.Find("contactScene(Clone)").transform);
    }

    public void OnClickInvite() {
        //Debug.Log("Invite");
    }

    public void InitFriend(string name) {
        nameText.text = name;
    }

}
