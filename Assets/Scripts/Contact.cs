using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{

    public GameObject oneFriend;
    public GameObject content;

    private string contactPath = "Data/contact";

    public void OnClickBack()
    {
        Destroy(gameObject);
    }

    //load from csv
    public void Start()
    {
        List<string> data = readCSV.readFile(contactPath);
        for (int i = 1; i < data.Count; i++)
        {
            var one = Instantiate(oneFriend, content.transform);
            var friendName = data[i].Split(",")[0];
            var friendLevel = data[i].Split(",")[1];
            one.GetComponent<OneFriend>().InitFriend(friendName);
        }
    }

}